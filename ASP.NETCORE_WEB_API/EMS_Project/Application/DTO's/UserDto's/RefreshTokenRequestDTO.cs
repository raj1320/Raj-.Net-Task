namespace EMS_Project.Application.DTO_s.UserDto_s
{
    public class RefreshTokenRequestDTO
    {
        public int UserId { get; set; }
        public string? RefreshToken { get; set; } = string.Empty;

    }
}
