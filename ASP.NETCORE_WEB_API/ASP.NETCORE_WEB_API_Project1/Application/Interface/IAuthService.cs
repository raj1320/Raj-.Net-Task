using ASP.NETCORE_WEB_API_Project1.Application.DTOs;



namespace ASP.NETCORE_WEB_API_Project1.Application.Interface
{
    public interface IAuthService
    {
        Task<ResponseDTO?> Register(UserDTO userDTO);
        Task<ResponseDTO?> Login(LoginDTO loginDTO);
       
    }
}
