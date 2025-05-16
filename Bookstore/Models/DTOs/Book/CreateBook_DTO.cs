namespace Bookstore.Models.DTOs.Book
{
    public class CreateBook_DTO
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public int EditionNumber { get; set; }
        public string? CoverText { get; set; }
        public string? CoverImage { get; set; }
        public List<int> AuthorIds { get; set; }
        public int? CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public string UserId { get; set; }
    }
}
