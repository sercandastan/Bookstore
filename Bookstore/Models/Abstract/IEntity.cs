using Bookstore.Enums;

namespace Bookstore.Models.Abstract
{
    public interface IEntity
    {
        public DateTime? CreatedAt { get; set; } //Eklendiği tarih

        public DateTime? UpdatedAt { get; set; } //Güncellendiği tarih

        public DateTime? DeletedAt { get; set; } //Silindiği tarih

        public Status? Status { get; set; }  //Kayıt durumu
    }
}
