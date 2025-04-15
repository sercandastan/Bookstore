namespace Bookstore.Models.DTOs.Author
{
    public class UpdateAuthor_DTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int? BirthYear { get; set; }
    }
}
