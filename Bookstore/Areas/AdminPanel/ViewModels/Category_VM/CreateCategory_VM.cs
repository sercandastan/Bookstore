using System.ComponentModel.DataAnnotations;

namespace Bookstore.Areas.AdminPanel.ViewModels.Category_VM
{
    public class CreateCategory_VM
    {
        [Required(ErrorMessage ="Kategori adı zorunludur")]
        [StringLength(50,ErrorMessage ="Kategori adı en fazla 50 karakter olabilir")]
        public string CategoryName { get; set; }
    }
}
