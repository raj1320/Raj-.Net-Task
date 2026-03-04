using AutoMapper;
using EMS_Project.Application.DTO_s.RegisterdEventDTO_s;
using EMS_Project.Application.Interfaces;
using EMS_Project.Domain.Interface;

namespace EMS_Project.Application.Services
{
    public class RegistrationServices : IRegistrationServices
    {
        private readonly IRegistrationRepository registrationRepository;
        private readonly IMapper mapper;

        public RegistrationServices(IRegistrationRepository registrationRepository,IMapper mapper)
        {
            this.registrationRepository = registrationRepository;
            this.mapper = mapper;
        }

        public async Task<List<RegisteredEventResponseDto>> ShowRegistrationService()
        {
            var result = await registrationRepository.ShowRegistrationService();
            return mapper.Map<List<RegisteredEventResponseDto>>(result);
        }
        public async Task<RegisteredEventResponseDto?> ShowRegistrationForOrganizationService(int OrganizationId)
        {
            var result = await registrationRepository.ShowRegistrationServiceForOrganization(OrganizationId);
            if (result == null) throw new KeyNotFoundException("User Not found!");
            return mapper.Map<RegisteredEventResponseDto>(result);
        }
    }
}
