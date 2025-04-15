using System.ComponentModel.DataAnnotations;

namespace Bookstore.Areas.AdminPanel.ViewModels.Author_VM
{
    public class UpdateAuthor_VM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yazar adı zorunludur")]
        [StringLength(30, ErrorMessage = "Yazar adı en fazla 30 karakter olabilir.")]
        public string FullName { get; set; }

        [Range(1000, 9999, ErrorMessage = "Doğum yılı 4 haneli olmalıdır (örn: 1985).")]
        public int? BirthYear { get; set; }

    }
}
