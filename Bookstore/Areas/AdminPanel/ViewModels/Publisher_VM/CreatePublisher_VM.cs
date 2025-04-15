using System.ComponentModel.DataAnnotations;

namespace Bookstore.Areas.AdminPanel.ViewModels.Publisher_VM
{
    public class CreatePublisher_VM
    {
        [Required(ErrorMessage = "Kategori adı zorunludur")]
        [StringLength(35, ErrorMessage = "Kategori adı en fazla 35 karakter olabilir")]
        public string PublisherName { get; set; }
    }
}
