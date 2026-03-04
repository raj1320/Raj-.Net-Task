using EMS_Project.Domain.Interface;
using EMS_Project.Application.DTO_s.UserDto_s;
using AutoMapper;
using EMS_Project.Application.DTO_s.RegisterdEventDTO_s;
using EMS_Project.Application.Interfaces;
namespace EMS_Project.Application.Services 
{ 
    public class UserService : IUserService
    {
        private readonly IUserRpository userRpository;
        private readonly IMapper _mapper;

        public UserService(IUserRpository userRpository, IMapper mapper)
        {
            this.userRpository = userRpository;
            this._mapper = mapper;
        }

        public async Task<ResponseUserDto?> GetUserService(int id)
        {
            var result= await userRpository.GetUser(id);
            if (result == null)
            {
                throw new KeyNotFoundException("User not found!");
            }
            return _mapper.Map<ResponseUserDto>(result);
        }

        public async Task<List<ResponseUserDto>> GetUsersService()
        {
            var result = await userRpository.GetUsers();
            return _mapper.Map<List<ResponseUserDto>>(result);
        }

        public async Task<RegisteredEventResponseDto?> RegiserToEventService(int UserId, int EventId)
        {
            var result = await userRpository.RegiserToEvent(UserId, EventId);
            if (result == null)
            {
                throw new KeyNotFoundException("User or Event not found!");
            }
            return _mapper.Map<RegisteredEventResponseDto>(result); 
        }

        public async Task<RegisteredEventResponseDto?> UnEnrolledToEvent(int UserId, int EventId)
        {
            var result = await userRpository.UnEnrolledToEvent(UserId, EventId);
            if (result == null)
            {
                throw new KeyNotFoundException("User or Event not found!");
            }
            return _mapper.Map<RegisteredEventResponseDto>(result); 
        }

        public async Task<List<RegisteredEventResponseDto>> CancelleEvent(int EventId)
        {
            var result = await userRpository.CancelleEvent(EventId);
            if (result == null)
            {
                throw new KeyNotFoundException("Event not found!");
            }
            return _mapper.Map<List<RegisteredEventResponseDto>>(result);
        }
    }
}
