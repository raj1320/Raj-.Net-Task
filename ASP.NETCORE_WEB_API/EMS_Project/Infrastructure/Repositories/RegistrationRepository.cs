using EMS_Project.Domain.Entities;
using EMS_Project.Domain.Interface;
using EMS_Project.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EMS_Project.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _Context;
        public RegistrationRepository(AppDbContext appDbContext) 
        {
           _Context = appDbContext;
        }

        public async Task<List<RegisteredEvent>> ShowRegistrationService()
        {
            var result = await _Context.RegisteredEvents.AsNoTracking().Include(x => x.User).Include(x => x.Event).ToListAsync();
            return result;
        }


        public async Task<List<RegisteredEvent>?> ShowRegistrationServiceForOrganization(int OrganizationId)
        {
            var Organization = await _Context.RegisteredEvents.AsNoTracking().SingleOrDefaultAsync(x => x.UserId == OrganizationId);
            if (Organization == null) return null;
            var result = await _Context.RegisteredEvents.AsNoTracking().Include(x => x.User).Include(x => x.Event).Where(x=>x.UserId==Organization.Id).ToListAsync();
            return result;
        }

    }
}
