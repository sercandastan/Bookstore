using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.DTOs.Login
{
    public class Login_DTO
    {
        [Required(ErrorMessage = "Email veya kullanıcı adı zorunludur.")]
        public string EmailOrUserName { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string Password { get; set; }
    }
}
