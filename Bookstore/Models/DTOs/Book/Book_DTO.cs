using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.DTOs.Book
{
    public class Book_DTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public int EditionNumber { get; set; }
        public string? CoverText { get; set; }
        public string? CoverImage { get; set; }
        public string? PublisherName { get; set; }
        public string? CategoryName { get; set; }
        public List<string>? AuthorNames { get; set; }

    }
}
