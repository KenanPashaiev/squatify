using AutoMapper;
using UserService.BL.Models.User;
using UserService.Core;

namespace UserService.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserUpdateDto, User>();

        }
    }
}