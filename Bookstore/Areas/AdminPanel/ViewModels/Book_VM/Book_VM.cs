using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Areas.AdminPanel.ViewModels.Book_VM
{
    public abstract class Book_VM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, 9999.99, ErrorMessage = "Fiyat geçerli bir değer olmalıdır.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Yayın yılı zorunludur.")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Baskı sayısı zorunludur.")]
        public int EditionNumber { get; set; }

        public string CoverText { get; set; }

        public IFormFile? CoverImage { get; set; }

        [Required(ErrorMessage = "Yayınevi seçiniz.")]
        public int? PublisherId { get; set; }

        [Required(ErrorMessage = "Kategori seçiniz.")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "En az bir yazar seçilmelidir.")]
        public List<int> AuthorIds { get; set; }

        // Dropdown verileri
        public SelectList? Authors { get; set; }
        public SelectList? Categories { get; set; }
        public SelectList? Publishers { get; set; }
    }
}
