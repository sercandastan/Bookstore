using Bookstore.Enums;
using Bookstore.Models.Abstract;

namespace Bookstore.Models
{
    public class BookAuthor:IEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; } //FK
        public int AuthorId { get; set; } //FK

        //IEntity
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        //Enum
        public Status? Status { get; set; }

        //Navigation Properties
        public Book? Book { get; set; }
        public Author? Author { get; set; }



    }
}
