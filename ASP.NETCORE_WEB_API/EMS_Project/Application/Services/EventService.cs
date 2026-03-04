using AutoMapper;
using EMS_Project.Application.DTO_s.EventDTO_s;
using EMS_Project.Application.Interfaces;
using EMS_Project.Domain.Entities;
using EMS_Project.Domain.Interface;

namespace EMS_Project.Application.Services
{
    public class EventService : IEventService
    {

        private readonly IEventRepository eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this._mapper = mapper;
        }

        public async Task<ResponseEventDto?> CreateEventService(int UserId,CreateEventDto createEventDto)
        {

            Event newEvent = _mapper.Map<Event>(createEventDto);
            var result = await eventRepository.AddEvent(UserId,newEvent);
            if (result == null)
            {
                throw new KeyNotFoundException("User not found!");
            }
            return _mapper.Map<ResponseEventDto>(result);
        }
     
        public async Task<ResponseEventDto?> UpdateEventService(int UserId, int EventId,UpdateEventDto updateEventDto)
        {
            Event UpdatedEvent = _mapper.Map<Event>(updateEventDto);
            var result = await eventRepository.UpdateEvent(UserId, EventId, UpdatedEvent);
            if (result == null)
            {
                throw new KeyNotFoundException("User or Event Is Invalid!");
            }
            return  _mapper.Map<ResponseEventDto>(result);

        }
     
        public async Task<ResponseEventDto?> UpdateByOrganizationService(int organizerId, int EventId,UpdateEventDto updateEventDto)
        {
            Event UpdatedEvent = _mapper.Map<Event>(updateEventDto);
            var result = await eventRepository.UpdateByOrganization(organizerId, EventId,UpdatedEvent);

            if (result == null)
            {
                throw new KeyNotFoundException("User or Event Is Invalid!");
            }
            return  _mapper.Map<ResponseEventDto>(result);

        }
     
        public async Task DeleteEventService(int id)
        {
            var result = await eventRepository.DeleteEvent(id);
            if (result == null)
            {
                throw new KeyNotFoundException("Event not found!");
            }
            return ;
        }
   
        public async Task<ResponseEventDto?> ShowEventService(int id)
        {
            var result = await eventRepository.GetEvent(id);
            if (result == null)
            {
                throw new KeyNotFoundException("Event not found!");
            }
            return _mapper.Map<ResponseEventDto>(result);
        }
        
        public async Task<List<ResponseEventDto>> ShowEventsService()
        {
            var result = await eventRepository.GetEvents();
            var ListOfResponseEventsDtos = _mapper.Map<List<ResponseEventDto>>(result);
            return ListOfResponseEventsDtos;
        }
    }
}
