using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class Author_CFG : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.FullName).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            builder.Property(a => a.BirthYear).HasColumnType("smallint").IsRequired(false);

            builder.HasData(
                new Author { Id = 1, FullName = "Matt Haig", BirthYear = 1990 },
                new Author { Id = 2, FullName = "George Orwell", BirthYear = 1903 },
                new Author { Id = 3, FullName = "Jane Austen", BirthYear = 1775 },
                new Author { Id = 4, FullName = "Stephen King", BirthYear = 1947 },
                new Author { Id = 5, FullName = "J.K. Rowling", BirthYear = 1965 },
                new Author { Id = 6, FullName = "Agatha Christie", BirthYear = 1890 },
                new Author { Id = 7, FullName = "Leo Tolstoy", BirthYear = 1828 },
                new Author { Id = 8, FullName = "Ernest Hemingway", BirthYear = 1899 },
                new Author { Id = 9, FullName = "Haruki Murakami", BirthYear = 1949 },
                new Author { Id = 10, FullName = "Gabriel Garcia Marquez", BirthYear = 1927 }
            );
        }
    }
}
