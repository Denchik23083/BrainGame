using AutoMapper;
using BrainGame.Auth.Models;
using BrainGame.Core;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.Auth.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginModel, User>();

            CreateMap<RegisterModel, User>();

            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            CreateMap<PasswordModel, Password>();
            CreateMap<Password, PasswordModel>();
        }
    }
}
