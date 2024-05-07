using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopOnline.API.Data;
using ShopOnline.API.Entities;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.Dtos;
using ShopOnline.Models.Responses;

namespace ShopOnline.API.Repositories
{
	public class UserAccount: IUserAccount
    {
        private readonly ShopOnlineDbContext dbContext;
        private readonly IConfiguration configuration;

        public UserAccount(ShopOnlineDbContext dbContext, IConfiguration configuration)
		{
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginUserDto userDto)
        {
            var existUser = await GetUser(userDto.Email);
            if (existUser == null) return new LoginResponse(false, "User doesn't exist");

            if (!BCrypt.Net.BCrypt.Verify(userDto.Password, existUser.Password))
                return new LoginResponse(false, "Email/Password not valid");

            string jwtToken = GenerateToken(existUser);
            return new LoginResponse(true, "Login successfully", jwtToken);

        }

        public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDto userDto)
        {
            var existUser = await GetUser(userDto.Email);
            if (existUser != null) return new RegistrationResponse(false, "User already exist");

            dbContext.Users.Add(
                new User ()
                {
                    Name = userDto.Name,
                    Email =userDto.Email,
                    Role = userDto.Role,
                    Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                    UserName = userDto.UserName
                }
            );

            await dbContext.SaveChangesAsync();

            return new RegistrationResponse(true, "Success");
        }

        private async Task<User> GetUser(string email)
        {
            return await this.dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        private string GenerateToken(User user)
        {
            var security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);

            var userClaim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"]!,
                audience: configuration["JWT:ValidAudience"]!,
                claims: userClaim,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

