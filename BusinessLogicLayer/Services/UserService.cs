using BusinessLogicLayer.Common;
using BusinessLogicLayer.IInterfaces;
using DTOs.UserDtos;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        public Task<LoginResult> Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterResult> Register(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
