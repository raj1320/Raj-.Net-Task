using AutoMapper;
using EMS_Project.Application.DTO_s.RegisterdEventDTO_s;
using EMS_Project.Domain.Entities;
using Microsoft.Extensions.Options;

namespace EMS_Project.Application.Mappings
{
    public class RegisteredEventMappingProfile : Profile
    {
        public RegisteredEventMappingProfile()
        {
            CreateMap<RegisteredEvent, RegisteredEventResponseDto>()
                .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Event.Name))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.EventStatusForUser, opt => opt.MapFrom(src => src.EventStatusForUser.ToString()));
            
        }
    }
}
