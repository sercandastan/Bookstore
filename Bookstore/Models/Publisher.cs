using Bookstore.Enums;
using Bookstore.Models.Abstract;

namespace Bookstore.Models
{
    public class Publisher:IEntity
    {
        public int Id { get; set; }
        public string PublisherName { get; set; }

        //IEntity
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        //Enum
        public Status? Status { get; set; }

        // Navigation Property
        public ICollection<Book>? Books { get; set; }




    }
}
