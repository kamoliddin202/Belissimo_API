using BusinessLogicLayer.Common;
using DataAccessLayer.Models;
using DTOs.UserDtos;

namespace BusinessLogicLayer.IInterfaces
{
    public interface IUserService
    {
        Task<RegisterResult> RegisterAsync(RegisterDto registerDto);
        Task<LoginResult> LoginAsync(LoginDto loginDto);
        Task<IEnumerable<User>> GetAllUsersAysnc();
    }
}
