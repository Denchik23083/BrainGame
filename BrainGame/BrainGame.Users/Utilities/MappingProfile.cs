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
            CreateMap<UserWriteModel, User>();
            CreateMap<User, UserReadModel>();

            CreateMap<PasswordModel, Password>();
        }
    }
}
