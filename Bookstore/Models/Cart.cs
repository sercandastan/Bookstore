using Bookstore.Enums;
using Bookstore.Models.Abstract;

namespace Bookstore.Models
{
    public class Cart : IEntity
    {
        public int Id { get; set; }
        public int KitapId { get; set; }  // FK
        public int UserId { get; set; }    // FK
        public short Quantity { get; set; }

        //IEntity
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        //Enum
        public Status? Status { get; set; }

        // Navigation Properties
        public Book? Book { get; set; }
        public AppUser? User { get; set; }
    }
}
