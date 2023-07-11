using AutoMapper;
using BrainGame.Auth.Models;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.Auth.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginModel, User>();

            CreateMap<RegisterModel, User>();

            CreateMap<RefreshTokenModel, RefreshToken>();

            CreateMap<Gender, GenderModel>();
        }
    }
}
