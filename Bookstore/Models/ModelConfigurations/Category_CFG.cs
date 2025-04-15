using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class Category_CFG : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();


            builder.HasData(
                new Category { Id = 1, CategoryName = "Roman" },
                new Category { Id = 2, CategoryName = "Bilim Kurgu" },
                new Category { Id = 3, CategoryName = "Korku" },
                new Category { Id = 4, CategoryName = "Felsefe" },
                new Category { Id = 5, CategoryName = "Polisiye" },
                new Category { Id = 6, CategoryName = "Klasik" },
                new Category { Id = 7, CategoryName = "Fantastik" },
                new Category { Id = 8, CategoryName = "Modern Edebiyat" },
                new Category { Id = 9, CategoryName = "Tarih" },
                new Category { Id = 10, CategoryName = "Latin Amerika Edebiyatı" }
            );


        }
    }
}
