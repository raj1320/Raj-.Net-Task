using EMS_Project.Domain.Enums;

namespace EMS_Project.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } =  string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Roles Role {  get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiry { get; set; }
        public List<Event> CreatedEvents { get; set; } = new List<Event>();
        public List<Event> UpdatedEvents { get; set; } = new List<Event>();
        public List<RegisteredEvent> RegisteredEvent { get; set; } = new List<RegisteredEvent>();


    }
}
