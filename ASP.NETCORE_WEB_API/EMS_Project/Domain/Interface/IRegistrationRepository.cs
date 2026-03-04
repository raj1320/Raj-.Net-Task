using EMS_Project.Domain.Entities;

namespace EMS_Project.Domain.Interface
{
    public interface IRegistrationRepository
    {
         Task<List<RegisteredEvent>> ShowRegistrationService();

         Task<List<RegisteredEvent>?> ShowRegistrationServiceForOrganization(int OrganizationId);
        
    }
}
