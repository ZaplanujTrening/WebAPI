using System.Collections.Generic;
using ZaplanujTreningAPI.Entities.Entities;
using ZaplanujTreningAPI.Entities.Models.Users;

namespace ZaplanujTreningAPI.Core.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
