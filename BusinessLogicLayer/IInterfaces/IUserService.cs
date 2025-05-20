using BusinessLogicLayer.Common;
using DTOs.UserDtos;

namespace BusinessLogicLayer.IInterfaces
{
    public interface IUserService
    {
        Task<RegisterResult> Register(RegisterDto registerDto);
        Task<LoginResult> Login(LoginDto loginDto);
    }
}
