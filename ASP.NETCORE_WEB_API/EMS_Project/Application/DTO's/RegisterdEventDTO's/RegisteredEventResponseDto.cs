using System.ComponentModel.DataAnnotations;

namespace EMS_Project.Application.DTO_s.RegisterdEventDTO_s;

public class RegisteredEventResponseDto
{

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string EventName { get; set; } = string.Empty;
    public string EventStatusForUser { get; set; } = string.Empty;

}
