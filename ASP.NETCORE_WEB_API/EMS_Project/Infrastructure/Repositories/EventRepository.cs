using EMS_Project.Domain.Entities;
using EMS_Project.Domain.Enums;
using EMS_Project.Domain.Interface;
using EMS_Project.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EMS_Project.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _Context;
       
        public EventRepository(AppDbContext appDbContext) 
        {
            _Context = appDbContext;
        }
        
        public async Task<Event?> GetEvent(int eventId)
        {
            return await _Context.Events.SingleOrDefaultAsync(x => x.Id == eventId);
        }

        public async Task<Event?> AddEvent(int UserId,Event newEvent)
        {
            User?usre = await _Context.Users.SingleOrDefaultAsync(x=>x.Id== UserId);
            if (usre == null) return null;
          
            newEvent.EventCreator=usre;
            await _Context.Events.AddAsync(newEvent);
            await  _Context.SaveChangesAsync();
            var result = _Context.Events.FirstOrDefault(x=>x.Name== newEvent.Name);
            
            return result;
        }

        public async Task<Event?> UpdateEvent(int UserId,int EventId,Event newEvent)
        {
            User?  user = await _Context.Users.SingleOrDefaultAsync(x=>x.Id == UserId);
            if (user == null) return null;

            var  result = await _Context.Events.SingleOrDefaultAsync(x=>x.Id == EventId);
            if(result != null)
            {
                result.Name = newEvent.Name;
                result.Description = newEvent.Description;
                result.Location = newEvent.Location;
                result.StartDate = newEvent.StartDate;
                result.EndDate = newEvent.EndDate;
                result.EventUpdator = user;
                await  _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Event?> UpdateByOrganization(int organizerId,int EventId,Event newEvent)
        {
            User? user = await _Context.Users.SingleOrDefaultAsync(x => x.Id == organizerId && x.Role== Roles.Organization);
            if (user == null) return null;

            var result = await _Context.Events.SingleOrDefaultAsync(x => x.Id == EventId && x.EventCreator==user);
            if (result != null)
            {
                result.Name = newEvent.Name;
                result.Description = newEvent.Description;
                result.Location = newEvent.Location;
                result.StartDate = newEvent.StartDate;
                result.EndDate = newEvent.EndDate;
                result.EventUpdator = user;
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<Event?> DeleteEvent(int id)
        {
            var result = await _Context.Events.SingleOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _Context.Events.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<List<Event>> GetEvents()
        {
            var result = await _Context.Events.AsNoTracking().Include(x => x.EventCreator).Include(x => x.EventUpdator).ToListAsync();
            return result;
        }

    }
}
