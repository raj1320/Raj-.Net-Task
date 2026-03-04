using System.ComponentModel.DataAnnotations;

namespace EMS_Project.Application.DTO_s.UserDto_s
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
