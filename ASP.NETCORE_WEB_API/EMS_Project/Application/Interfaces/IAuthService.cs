using AutoMapper;
using EMS_Project.Application.DTO_s.UserDto_s;
using EMS_Project.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS_Project.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseTokenDto?> Register(RegisterUserDto userDTO);
        Task<ResponseTokenDto?> Login(LoginUserDto loginDTO);
        Task<ResponseTokenDto?> RefreshTokenRequestService(RefreshTokenRequestDTO refreshTokenRequest);       

    }
}
