using System.Reflection;
using System.Reflection.Emit;
using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;



namespace Bookstore.Data
{
    public class BookstoreDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        private readonly IConfiguration _config;
        public BookstoreDbContext(IConfiguration config, DbContextOptions<BookstoreDbContext> options) : base(options)
        {
            _config = config;
        }

        //DbSets

        public DbSet<AppUser> Users { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Publisher> Publishers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Tüm konfigürasyonları uygular
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

            //Başlangıçta kullanıcıya atanılar rolü sağlar
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 2, RoleId = 2 });
        }


    }
}
