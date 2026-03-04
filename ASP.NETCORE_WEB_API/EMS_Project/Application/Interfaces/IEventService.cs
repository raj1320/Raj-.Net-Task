using EMS_Project.Application.DTO_s.EventDTO_s;

namespace EMS_Project.Application.Interfaces
{
    public interface IEventService 
    {
        Task<ResponseEventDto?> CreateEventService(int UserId,CreateEventDto createEventDto);
        Task<ResponseEventDto?> UpdateEventService(int UserId,int EventId,UpdateEventDto updateEventDto);
        Task<ResponseEventDto?> UpdateByOrganizationService(int organizerId, int EventId, UpdateEventDto updateEventDto);
        Task DeleteEventService(int id);
        Task<ResponseEventDto?> ShowEventService(int id);
        Task<List<ResponseEventDto>> ShowEventsService();
    }
}
