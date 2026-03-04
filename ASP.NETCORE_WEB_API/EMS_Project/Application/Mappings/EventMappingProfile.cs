using AutoMapper;
using EMS_Project.Application.DTO_s.EventDTO_s;
using EMS_Project.Domain.Entities;

namespace EMS_Project.Application.Mappings
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile() 
        {
            CreateMap<CreateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
            CreateMap<Event,ResponseEventDto>();
        }
    }
}
