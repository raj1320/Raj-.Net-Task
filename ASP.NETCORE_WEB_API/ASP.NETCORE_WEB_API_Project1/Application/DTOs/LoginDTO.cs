using System.ComponentModel.DataAnnotations;

namespace ASP.NETCORE_WEB_API_Project1.Application.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
