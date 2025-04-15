using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Areas.AdminPanel.ViewModels.Book_VM
{
    public class UpdateBook_VM
    {
        // Id Sadece güncelleme işlemi için kullanılır. Create sırasında boş bırakılır.
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Kitap adı en fazla 50 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fiyat girilmelidir.")]
        [Range(0.01, 999999.99, ErrorMessage = "Fiyat 0.01 TL ile 999999.99 TL arasında olmalıdır.")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Yayın yılı zorunludur.")]
        [Range(1500, 2100, ErrorMessage = "Yayın yılı 1500 ile 2100 arasında olmalıdır.")]
        public int? PublicationYear { get; set; }

        [Required(ErrorMessage = "Baskı sayısı zorunludur.")]
        [Range(1, 1000, ErrorMessage = "Baskı sayısı 1 ile 1000 arasında olmalıdır.")]
        public int? EditionNumber { get; set; }

        [Required(ErrorMessage = "Kapak yazısı boş bırakılamaz.")]
        [StringLength(256, ErrorMessage = "Kapak yazısı en fazla 256 karakter olabilir.")]
        public string CoverText { get; set; }

        public IFormFile? CoverImage { get; set; }

        [Required(ErrorMessage = "Yayınevi seçilmelidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir yayınevi seçiniz.")]
        public int? PublisherId { get; set; }

        [Required(ErrorMessage = "Kategori seçilmelidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir kategori seçiniz.")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "En az bir yazar seçilmelidir.")]
        [MinLength(1, ErrorMessage = "En az bir yazar seçilmelidir.")]
        public List<int> AuthorIds { get; set; } = new();

        // DropDown’lar (seçim listeleri)
        public SelectList? Publishers { get; set; }
        public SelectList? Categories { get; set; }
        public SelectList? Authors { get; set; }
    }
}
