using System.ComponentModel.DataAnnotations;

namespace DTOs.UserDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required !")]
        [StringLength(50, ErrorMessage = "Belgilar 50 tadan oshmasin !")]
        [MinLength(5, ErrorMessage = "Eng kami 5 belgi ishlaish kerak !")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required !")]
        [StringLength(20, ErrorMessage = "Password 20 tadan ko'p bo'lmasligi kerak !")]
        [MinLength(5, ErrorMessage = "Password 5 tadan kam bo'lmasligi kerak !")]
        public string Password { get; set; }
    }
}
