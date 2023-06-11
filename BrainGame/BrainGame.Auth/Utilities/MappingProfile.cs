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
            CreateMap<User, LoginModel>();

            CreateMap<RegisterModel, User>();
            CreateMap<User, RegisterModel>();

            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            CreateMap<PasswordModel, Password>();
            CreateMap<Password, PasswordModel>();
        }
    }
}
