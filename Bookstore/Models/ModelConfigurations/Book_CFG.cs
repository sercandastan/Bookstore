using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class Book_CFG : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(b => b.Price).HasColumnType("money").IsRequired();
            builder.Property(b => b.PublicationYear).HasColumnType("smallint").IsRequired();
            builder.Property(b => b.EditionNumber).HasColumnType("int").IsRequired();
            builder.Property(b => b.CoverText).HasColumnType("nvarchar(256)").IsRequired();

            builder.Property(b => b.CategoryId).IsRequired();
            builder.Property(b => b.PublisherId).IsRequired();
            builder.Property(b => b.UserId).IsRequired();

            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "",
                    Price = 100,
                    EditionNumber = 100,
                    PublicationYear = 2000,
                    CategoryId = 1,
                    PublisherId = 1,
                    CoverText = "",
                    CoverImage = ""
                });

            
        }
    }
}
