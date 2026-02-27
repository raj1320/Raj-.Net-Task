using ASP.NETCORE_WEB_API_Project1.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCORE_WEB_API_Project1.Application.DTOs
{
    public class UserDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(255,ErrorMessage ="Enter valid format of Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(8,MinimumLength =5)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public UserRoles Role { get; set; } 

    }
}
