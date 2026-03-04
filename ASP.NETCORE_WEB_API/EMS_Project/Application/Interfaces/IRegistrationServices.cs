using EMS_Project.Application.DTO_s.RegisterdEventDTO_s;

namespace EMS_Project.Application.Interfaces
{
    public interface IRegistrationServices
    {

        Task<List<RegisteredEventResponseDto>> ShowRegistrationService();

        Task<RegisteredEventResponseDto?> ShowRegistrationForOrganizationService(int OrganizationId);
       
    }
}
