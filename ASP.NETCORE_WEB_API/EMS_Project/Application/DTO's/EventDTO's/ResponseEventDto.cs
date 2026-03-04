using System.ComponentModel.DataAnnotations;

namespace EMS_Project.Application.DTO_s.EventDTO_s
{
    public class ResponseEventDto : CreateEventDto
    {
        [Required]
        public int LastUpdateBy { get; set; }
    }
}
