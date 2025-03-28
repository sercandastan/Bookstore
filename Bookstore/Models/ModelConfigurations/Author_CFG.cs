using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class Author_CFG : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasColumnType("nvarchar(25)");
            builder.Property(a => a.BirthYear).HasColumnType("smallint");

            builder.HasData(
                new Author { Id = 1, Name = "Matt Haig", BirthYear = 1990 },
                new Author { Id = 2, Name = "George Orwell", BirthYear = 1903 },
                new Author { Id = 3, Name = "Jane Austen", BirthYear = 1775 },
                new Author { Id = 4, Name = "Stephen King", BirthYear = 1947 },
                new Author { Id = 5, Name = "J.K. Rowling", BirthYear = 1965 },
                new Author { Id = 6, Name = "Agatha Christie", BirthYear = 1890 },
                new Author { Id = 7, Name = "Leo Tolstoy", BirthYear = 1828 },
                new Author { Id = 8, Name = "Ernest Hemingway", BirthYear = 1899 },
                new Author { Id = 9, Name = "Haruki Murakami", BirthYear = 1949 },
                new Author { Id = 10, Name = "Gabriel Garcia Marquez", BirthYear = 1927 }
            );




        }
    }
}
