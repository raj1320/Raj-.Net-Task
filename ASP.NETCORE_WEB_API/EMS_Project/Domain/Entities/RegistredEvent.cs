using EMS_Project.Domain.Enums;

namespace EMS_Project.Domain.Entities
{
    public class RegisteredEvent
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public EventStatusForUser EventStatusForUser { get; set; }

        public User User { get; set; } = null!;
        public Event Event { get; set; } = null!;

    }
}
