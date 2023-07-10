using AutoMapper;
using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;
using BrainGame.Users.Models;

namespace BrainGame.Users.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            CreateMap<PasswordModel, Password>();
            CreateMap<Password, PasswordModel>();
        }
    }
}
