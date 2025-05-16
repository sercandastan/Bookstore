using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.ViewModels.Login_VM
{
    public class Login_VM
    {
        [Required(ErrorMessage = "Email veya kullanıcı adı zorunludur.")]
        public string EmailOrUserName { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string Password { get; set; }
    }
}
