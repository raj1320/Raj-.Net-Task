using System.ComponentModel.DataAnnotations;

namespace EMS_Project.Application.DTO_s.EventDTO_s
{
    public class UpdateEventDto 
    {

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
