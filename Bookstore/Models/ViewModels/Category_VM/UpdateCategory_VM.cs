using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.ViewModels.Category_VM
{
    public class UpdateCategory_VM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur")]
        [StringLength(50, ErrorMessage = "Kategori adı en fazla 50 karakter olabilir")]
        public string CategoryName { get; set; }
    }
}
