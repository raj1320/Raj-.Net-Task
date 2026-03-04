using EMS_Project.Domain.Entities;
using EMS_Project.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EMS_Project.Application.DTO_s.UserDto_s
{
    public class RegisterUserDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public Roles Role { get; set; }
       
    }
}
