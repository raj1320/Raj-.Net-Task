using ASP.NETCORE_WEB_API_Project1.Domain.Enums;

namespace ASP.NETCORE_WEB_API_Project1.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRoles Role { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
