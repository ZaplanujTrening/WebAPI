using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using ZaplanujTreningAPI.Core.Services.Interfaces;
using ZaplanujTreningAPI.Entities.Models;
using ZaplanujTreningAPI.Utils.Helpers;

namespace ZaplanujTreningAPI.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}
