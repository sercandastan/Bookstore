using Bookstore.Enums;
using Bookstore.Models.Abstract;

namespace Bookstore.Models
{
    public class Author :IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? BirthYear { get; set; }

        //IEntity
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } 
        public DateTime? DeletedAt { get; set; } 

        //Enum
        public Status? Status { get; set; }

        // Navigation Property
        public ICollection<BookAuthor>? BookAuthors { get; set; }

        
    }
}
