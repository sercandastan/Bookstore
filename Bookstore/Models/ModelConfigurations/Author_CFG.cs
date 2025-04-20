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
                new Author { Id = 1, FullName = "Matt Haig", BirthYear = 1990,CreatedAt=DateTime.Now,Status=Enums.Status.Added},
                new Author { Id = 2, FullName = "George Orwell", BirthYear = 1903,CreatedAt=DateTime.Now,Status = Enums.Status.Added },
                new Author { Id = 3, FullName = "Jane Austen", BirthYear = 1775,CreatedAt=DateTime.Now,Status = Enums.Status.Added  },
                new Author {Id = 4, FullName = "Stephen King", BirthYear = 1947, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 5, FullName = "J.K. Rowling", BirthYear = 1965, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 6, FullName = "Agatha Christie", BirthYear = 1890, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 7, FullName = "Leo Tolstoy", BirthYear = 1828, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 8, FullName = "Ernest Hemingway", BirthYear = 1899, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 9, FullName = "Haruki Murakami", BirthYear = 1949, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 10, FullName = "Gabriel Garcia Marquez", BirthYear = 1927, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 11, FullName = "Orhan Pamuk", BirthYear = 1952, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 12, FullName = "Elif Şafak", BirthYear = 1971, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 13, FullName = "Fyodor Dostoevsky", BirthYear = 1821, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 14, FullName = "Marcel Proust", BirthYear = 1871, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 15, FullName = "Virginia Woolf", BirthYear = 1882, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 16, FullName = "Hermann Hesse", BirthYear = 1877, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 17, FullName = "Mark Twain", BirthYear = 1835, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 18, FullName = "Franz Kafka", BirthYear = 1883, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 19, FullName = "Paulo Coelho", BirthYear = 1947, CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Author {Id = 20, FullName = "Dan Brown", BirthYear = 1964, CreatedAt = DateTime.Now, Status = Enums.Status.Added }
            );
        }
    }
}
