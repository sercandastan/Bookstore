using Bookstore.Enums;

namespace Bookstore.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; } //FK

        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus { get; set; }



        public AppUser User { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

    }
}
