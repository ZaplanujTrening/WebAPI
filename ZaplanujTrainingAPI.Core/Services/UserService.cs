using BCryptNet = BCrypt.Net.BCrypt;
using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using ZaplanujTreningAPI.Core.Services.Interfaces;
using ZaplanujTreningAPI.Entities.Entities;
using ZaplanujTreningAPI.Entities.Models;
using ZaplanujTreningAPI.Entities.Models.Users;
using ZaplanujTreningAPI.Utils.Helpers;
using ZaplanujTreningAPI.Core.Repositories.Interfaces;

namespace ZaplanujTreningAPI.Core.Services
{
    public class UserService : IUserService
    {
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;

        public UserService(
            IUserRepository userRepo,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            _userRepo = userRepo;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var user = _userRepo.GetByUsername(model.Username);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            user.RefreshTokens.Add(refreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            _userRepo.Update(user);
            _userRepo.SaveChanges();

            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var user = getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                // revoke all descendant tokens in case this token has been compromised
                revokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                _userRepo.Update(user);
                _userRepo.SaveChanges();
            }

            if (!refreshToken.IsActive)
                throw new AppException("Invalid token");

            // replace old refresh token with a new one (rotate token)
            var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress);
            user.RefreshTokens.Add(newRefreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            _userRepo.Update(user);
            _userRepo.SaveChanges();

            // generate new jwt
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var user = getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.IsActive)
                throw new AppException("Invalid token");

            // revoke token and save
            revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            _userRepo.Update(user);
            _userRepo.SaveChanges();
        }

        public void Register(RegisterUserRequest model)
        {
            // validate
            if (_userRepo.GetByUsername(model.Username) != null)
                throw new AppException("Username '" + model.Username + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(model.Password);

            // save user
            _userRepo.Add(user);
            _userRepo.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetUsers();
        }

        public User GetById(int id)
        {
            var user = _userRepo.GetUserById(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        // helper methods
        private User getUserByRefreshToken(string token)
        {
            var user = _userRepo.GetWhere(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                throw new AppException("Invalid token");

            return user;
        }

        private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private void removeOldRefreshTokens(User user)
        {
            // remove old inactive refresh tokens from user based on TTL in app settings
            user.RefreshTokens.RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }

        private void revokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ipAddress, string reason)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                    revokeRefreshToken(childToken, ipAddress, reason);
                else
                    revokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
            }
        }

        private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }
    }
}
