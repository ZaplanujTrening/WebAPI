using AutoMapper;
using ZaplanujTreningAPI.Entities.Entities;
using ZaplanujTreningAPI.Entities.Models.Users;

namespace ZaplanujTreningAPI.Utils.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<RegisterRequest, User>();
        }
    }
}
