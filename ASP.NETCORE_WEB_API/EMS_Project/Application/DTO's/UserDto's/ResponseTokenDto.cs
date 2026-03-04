namespace EMS_Project.Application.DTO_s.UserDto_s
{
    public class ResponseTokenDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; }= string.Empty;
    }
}
