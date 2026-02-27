using ASP.NETCORE_WEB_API_Project1.Application.DTOs;
using ASP.NETCORE_WEB_API_Project1.Infrastructure.Data;
using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AutoMapper;
using ASP.NETCORE_WEB_API_Project1.Application.Interface;

namespace ASP.NETCORE_WEB_API_Project1.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _Context;
        private readonly IConfiguration configuration;
        public IMapper Mapper;


        public AuthService(AppDbContext context,IConfiguration configuration,IMapper mapper)
        {
            this.configuration= configuration;
            this.Mapper =mapper;
            _Context = context;
        }

        public async Task<ResponseDTO?> Register(UserDTO userDTO)
        {
            var result = await _Context.Users.SingleOrDefaultAsync(x => x.Email == userDTO.Email);
            if (result is not null) return null;

            User newUser = new User();

            newUser.Email = userDTO.Email;
            newUser.Name = userDTO.Name;
            newUser.PasswordHash = new PasswordHasher<User>().HashPassword(newUser, userDTO.Password);
            newUser.Role = userDTO.Role;

             await _Context.Users.AddAsync(newUser);
             await _Context.SaveChangesAsync();

            return new ResponseDTO()
            {
                AccessToken = await CreateToken(userDTO)
            };
        }

        public async Task<ResponseDTO?> Login(LoginDTO loginDTO)
        {
            var user = await _Context.Users.SingleOrDefaultAsync(x => x.Email == loginDTO.Email) ;
         
            if (user is null) return null;

            if(new PasswordHasher<User>().VerifyHashedPassword(user,user.PasswordHash,loginDTO.Password) == PasswordVerificationResult.Failed) { return null; }

           
            return new ResponseDTO()
            {

                AccessToken = await CreateToken(Mapper.Map<UserDTO>(user))
            };
        }

        private async Task<string> CreateToken(UserDTO userDTO)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, userDTO.Email),
                new Claim(ClaimTypes.Role,userDTO.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier,userDTO.Id.ToString()),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]!));
            var Creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(

                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: Claims,
                expires : DateTime.UtcNow.AddDays(1),
                signingCredentials: Creds

                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}
