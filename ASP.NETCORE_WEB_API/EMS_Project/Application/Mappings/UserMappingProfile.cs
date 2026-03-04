using AutoMapper;
using EMS_Project.Application.DTO_s.UserDto_s;
using EMS_Project.Domain.Entities;

namespace EMS_Project.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<LoginUserDto, User>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, RegisterUserDto>();
            CreateMap<User, ResponseUserDto>();
            CreateMap<User, RefreshTokenRequestDTO>();
        }
    }
}
