using EMS_Project.Infrastructure.Data;
using EMS_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EMS_Project.Domain.Interface;
using EMS_Project.Domain.Enums;
namespace EMS_Project.Infrastructure.Repositories
{
    public class UserRepository : IUserRpository
    {
        private readonly AppDbContext _Context;
        public UserRepository(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }

        public  async Task<User?> GetUser(int id)
        {
            return await _Context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _Context.Users.AsNoTracking().Include(x=>x.CreatedEvents).Include(x=>x.RegisteredEvent).ThenInclude(x=>x.Event).ToListAsync();
        }

       public async Task<RegisteredEvent?> RegiserToEvent(int UserId,int EventId)
        {
            var AlreadyRegister = await _Context.RegisteredEvents.SingleOrDefaultAsync(x => x.UserId == UserId && x.EventId == EventId);
            if (AlreadyRegister != null) return null;

            RegisteredEvent registeredEvent = new RegisteredEvent();
            registeredEvent.UserId = UserId;
            registeredEvent.EventId = EventId;
            await _Context.AddAsync(registeredEvent);
            await _Context.SaveChangesAsync();
            var RGEvent = await _Context.RegisteredEvents.AsNoTracking().Include(x=>x.Event).Include(x=>x.User).SingleOrDefaultAsync(x => x.UserId == UserId && x.EventId == EventId);
            return RGEvent;
        }

        public async Task<RegisteredEvent?> UnEnrolledToEvent(int UserId, int EventId)
        {
            var RGEvent = await _Context.RegisteredEvents.Include(x => x.Event).Include(x => x.User).SingleOrDefaultAsync(x => x.UserId == UserId && x.EventId == EventId);
            if (RGEvent == null) return null;
            RGEvent.EventStatusForUser = EventStatusForUser.UnEnrolled;
            await _Context.SaveChangesAsync();
            return RGEvent;
        }

        public async Task<List<RegisteredEvent>?> CancelleEvent(int EventId)
        {
            
            var RGEvent = await _Context.RegisteredEvents.Include(x => x.Event).Include(x => x.User).Where(x => x.EventId == EventId).ToListAsync();
            if (!RGEvent.Any()) return null;
            List<RegisteredEvent> registeredEvents = new List<RegisteredEvent>();
            foreach(var  registration in RGEvent)
            {
                registration.EventStatusForUser = EventStatusForUser.Cancelle;
                registeredEvents.Add(registration);
            }
            await _Context.SaveChangesAsync();
            return registeredEvents;
        }
    }
}
