using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Common;
using BusinessLogicLayer.IInterfaces;
using DataAccessLayer.Models;
using DTOs.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public UserService(UserManager<User> user, IConfiguration configuration)
        {
            _userManager = user;
            _configuration = configuration;
        }
        public async Task<LoginResult> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return new LoginResult
                {
                    Message = "Bunday foydalanuvchi Databaseda yo'q !",
                    IsSuccess = false,
                };
            }
            var checkpassord = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!checkpassord)
            {
                return new LoginResult
                {
                    Message = "Password noto'g'ri !",
                    IsSuccess = false,
                };
            }

            var token = await GenerateToken(user);

            return new LoginResult
            {
                Message = token,
                IsSuccess = true,
            };


        }

        public async Task<RegisterResult> RegisterAsync(RegisterDto registerDto)
        {
            var result = await _userManager.FindByEmailAsync(registerDto.Email);
            if (result != null)
            {
                throw new CustomException("Bunday foydalanuvchi databaseda bor !");
            }

            var User = new User
            {
                FullName = registerDto.FullName,
                UserName = registerDto.FullName,
                Email = registerDto.Email,
                Address = registerDto.Address
            };
            var createdUser = await _userManager.CreateAsync(User, registerDto.Password);

            if (!createdUser.Succeeded)
            {
                var createdUserErrorResult = string.Join(';', createdUser.Errors.Select(c => c.Description));
                throw new CustomException("User yaratilmadi !" + createdUserErrorResult);
            }

            var roleResult = await _userManager.AddToRoleAsync(User, "User");
            if (!roleResult.Succeeded)
            {
                return new RegisterResult
                {
                    Message = "User yaratilmadi !" + roleResult.Errors.Select(c => c.Description),
                    IsSuccess = false,
                    ExpireTime = DateTime.Now
                };
            }

            return new RegisterResult
            {
                Message = "User yaratildi !",
                IsSuccess = true,
                ExpireTime = DateTime.Now
            };
        }

        public async Task<string> GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
            };


            var tokenHandler = new JwtSecurityTokenHandler();
                
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);


        }

        public async Task<IEnumerable<User>> GetAllUsersAysnc()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
