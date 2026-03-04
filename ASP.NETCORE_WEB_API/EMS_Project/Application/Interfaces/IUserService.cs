using EMS_Project.Application.DTO_s.RegisterdEventDTO_s;
using EMS_Project.Application.DTO_s.UserDto_s;

namespace EMS_Project.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResponseUserDto?> GetUserService(int id);
        Task<List<ResponseUserDto>> GetUsersService();
        Task<RegisteredEventResponseDto?> RegiserToEventService(int UserId, int EventId);
        Task<RegisteredEventResponseDto?> UnEnrolledToEvent(int UserId, int EventId);
        Task<List<RegisteredEventResponseDto>> CancelleEvent(int EventId);
       
    }
}
