using EMS_Project.Domain.Entities;
using EMS_Project.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EMS_Project.Application.DTO_s.UserDto_s
{
    public class ResponseUserDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Roles Role { get; set; }
        public List<Event> CreatedEvents { get; set; } = new List<Event>();
        public List<Event> UpdatedEvents { get; set; } = new List<Event>();
        public List<RegisteredEvent> RegisteredEvent { get; set; } = new List<RegisteredEvent>();

    }
}
