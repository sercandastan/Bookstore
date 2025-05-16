using Bookstore.Enums;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.ViewModels.Register_VM
{
    public class Register_VM
    {
        [Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
        [Required] public string UserName { get; set; }
        [Required, DataType(DataType.Password)] public string Password { get; set; }
        [Compare("Password"), DataType(DataType.Password)] public string ConfirmPassword { get; set; }
    }
}
