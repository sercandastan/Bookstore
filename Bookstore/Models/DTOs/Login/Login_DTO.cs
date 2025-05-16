using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.DTOs.Login
{
    public class Login_DTO
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }
}
