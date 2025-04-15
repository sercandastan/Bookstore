namespace Bookstore.Models.DTOs.Book
{
    public class BookDetail_DTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int PublicationYear { get; set; }
        public int EditionNumber { get; set; }
        public string CoverText { get; set; }
        public string CoverImage { get; set; }
        public int PublisherId { get; set; }
        public string? PublisherName { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<int> AuthorIds { get; set; } = new();
        public List<string>? AuthorNames { get; set; }
    }
}
