namespace Bookstore.Models.ViewModels.Book_VM
{
    public class DetailsBook_VM 
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int PublicationYear { get; set; }

        public int EditionNumber { get; set; }

        public string CoverText { get; set; }

        public string CoverImage { get; set; } = string.Empty;

        public int PublisherId { get; set; }

        public string? PublisherName { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public List<string> AuthorNames { get; set; } = new();
    }
}
