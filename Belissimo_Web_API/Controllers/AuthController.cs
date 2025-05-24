using BusinessLogicLayer.Common;
using BusinessLogicLayer.IInterfaces;
using DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace Belissimo_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register", Name = "Register User")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userService.RegisterAsync(registerDto);
                return Ok(result);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "serverda xatolik yuz berdi !", detail = ex.Message });
            }
        }

        [HttpPost("Login", Name = "Login user")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userService.LoginAsync(loginDto);
                return Ok(result);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "serverda xatolik yuz berdi !", detail = ex.Message });
            }
        }

        [HttpGet("allusers", Name = "GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAysnc();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
