namespace Bookstore.Models.DTOs.Book
{
    public class UpdateBook_DTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public int EditionNumber { get; set; }
        public string CoverText { get; set; }
        public string? CoverImage { get; set; }

        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}