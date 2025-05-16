namespace Bookstore.Models.ViewModels.Cart_VM
{
    public class Cart_VM
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public short Quantity { get; set; }

        public string CoverImage { get; set; }

        public decimal TotalPrice => (decimal)Price * Quantity;




    }
}
