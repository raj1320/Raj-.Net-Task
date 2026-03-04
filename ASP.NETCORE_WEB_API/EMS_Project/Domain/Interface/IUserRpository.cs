using EMS_Project.Domain.Entities;
using EMS_Project.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EMS_Project.Domain.Interface
{
    public interface IUserRpository
    {
        Task<User?> GetUser(int id);


         Task<List<User>> GetUsers();


        Task<RegisteredEvent?> RegiserToEvent(int UserId, int EventId);


        Task<RegisteredEvent?> UnEnrolledToEvent(int UserId, int EventId);


        Task<List<RegisteredEvent>?> CancelleEvent(int EventId);
       
    }
}
