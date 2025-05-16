using Bookstore.Enums;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.Models
{
    public class AppUser :IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        //Enum
        public Gender Gender { get; set; }

        //Navigation Property
        public ICollection<Book>? Books { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
