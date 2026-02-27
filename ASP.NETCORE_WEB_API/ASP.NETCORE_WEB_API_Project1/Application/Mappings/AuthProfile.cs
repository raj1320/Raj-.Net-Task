using AutoMapper;
using ASP.NETCORE_WEB_API_Project1.Application.DTOs;
using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
namespace ASP.NETCORE_WEB_API_Project1.Application.Mappings
{
    public class AuthProfile : Profile
    {
        public AuthProfile() 
        {
            CreateMap<UserDTO,User>();

            CreateMap<User,UserDTO>();

            CreateMap<LoginDTO, User>();
           
            CreateMap<User, LoginDTO>();

            CreateMap<ResponseDTO,User>();

            CreateMap<User,ResponseDTO>();
        }
    }
}
