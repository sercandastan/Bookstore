using Bookstore.Enums;
using Bookstore.Models.Abstract;

namespace Bookstore.Models
{
    public class Book:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } //Adı
        public double Price { get; set; } //Fiyatı
        public int PublicationYear { get; set; } //İlk yayınlandığı yıl
        public int EditionNumber { get; set; } //Baskı sayısı
        public string CoverText { get; set; } //Arka kapağındaki yazı
        public string CoverImage { get; set; } //Kapak görselinin yolu/URLSi

        //IEntity
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        //Enum
        public Status? Status { get; set; }

        //Foreign Keys
        public int CategoryId { get; set; }
        public int PublisherId {  get; set; }
        public int UserId { get; set; }

        //Navigation Properties
        public Category? Category { get; set; }
        public Publisher? Publisher { get; set; }
        public AppUser? User { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
