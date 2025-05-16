using Bookstore.Enums;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.DTOs.Register
{
    public class Register_DTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }


        public string Email { get; set; }

        public string UserName { get; set; }


        public string Password { get; set; }

  
        public string ConfirmPassword { get; set; }


    }
}
