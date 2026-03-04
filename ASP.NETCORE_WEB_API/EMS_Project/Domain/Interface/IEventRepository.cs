using EMS_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS_Project.Domain.Interface
{
    public interface IEventRepository
    {
      Task<Event?> GetEvent(int eventId);

        Task<Event?> AddEvent(int UserId, Event newEvent);

        Task<Event?> UpdateEvent(int UserId, int EventId, Event newEvent);

        Task<Event?> UpdateByOrganization(int organizerId, int EventId, Event newEvent);

        Task<Event?> DeleteEvent(int id);

        Task<List<Event>> GetEvents();
        
    }
}