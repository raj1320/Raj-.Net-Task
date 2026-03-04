using AutoMapper;
using EMS_Project.Application.DTO_s.UserDto_s;
using EMS_Project.Application.Interfaces;
using EMS_Project.CustomException;
using EMS_Project.Domain.Entities;
using EMS_Project.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EMS_Project.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _Context;
        private readonly IConfiguration configuration;
        public IMapper Mapper;


        public AuthService(AppDbContext context, IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this.Mapper = mapper;
            _Context = context;
        }

        public async Task<ResponseTokenDto?> Register(RegisterUserDto userDTO)
        {
            var result = await _Context.Users.SingleOrDefaultAsync(x => x.Email == userDTO.Email);
            if (result is not null)  throw new ConflictException("User already exsist!");

            User newUser = new User();

            newUser.Email = userDTO.Email;
            newUser.Name = userDTO.Name;
            newUser.PasswordHash = new PasswordHasher<User>().HashPassword(newUser, userDTO.Password);
            newUser.Role = userDTO.Role;

            await _Context.Users.AddAsync(newUser);
            await _Context.SaveChangesAsync();

            var ResDto = Mapper.Map<ResponseUserDto>(newUser);

            return new ResponseTokenDto()
            {
                AccessToken = await CreateToken(newUser),
                RefreshToken = await GenerateAndSaveRefreshToken(newUser)
            };
        }

        public async Task<ResponseTokenDto?> Login(LoginUserDto loginDTO)
        {
            var user = await _Context.Users.SingleOrDefaultAsync(x => x.Email == loginDTO.Email);

            if (user is null) throw new KeyNotFoundException("Invalid emial or password.");

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, loginDTO.Password) == PasswordVerificationResult.Failed) { return null; }

            return new ResponseTokenDto()
            {
                AccessToken = await CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshToken(user)
            };
        }

        private async Task<string> CreateToken(User user)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role,user.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]!));
            var Creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(

                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: Claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: Creds

                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public async Task<ResponseTokenDto?> RefreshTokenRequestService(RefreshTokenRequestDTO refreshTokenRequest)
        {
            var user = await _Context.Users.FindAsync(refreshTokenRequest.UserId);
            if (user is null || user.RefreshToken != refreshTokenRequest.RefreshToken) throw new KeyNotFoundException("User Not Found!");
            var resultDto = new ResponseTokenDto()
            {
                AccessToken = await CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshToken(user)

            };
            user.RefreshToken = resultDto.RefreshToken;
            _Context.SaveChanges();
            return resultDto;
        }

        private async Task<string> GenerateAndSaveRefreshToken(User user)
        {

            var randomnumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomnumber);
            var refreshToken = Convert.ToBase64String(randomnumber);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(2);
            await _Context.SaveChangesAsync();
            return refreshToken;
        }
    }
}

