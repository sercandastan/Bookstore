using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class Publisher_CFG : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(p => p.PublisherName).HasColumnType("nvarchar").HasMaxLength(35).IsRequired();

            builder.HasData(
                new Publisher { Id = 1, PublisherName = "Pegasus Yayınları",CreatedAt = DateTime.Now,Status=Enums.Status.Added },
                new Publisher {Id = 2, PublisherName = "Can Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 3, PublisherName = "İş Bankası Kültür Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 4, PublisherName = "Altın Kitaplar", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 5, PublisherName = "YKY", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 6, PublisherName = "Epsilon Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 7, PublisherName = "Remzi Kitabevi", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 8, PublisherName = "Everest Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 9, PublisherName = "Doğan Kitap", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 10, PublisherName = "Kafka Kitap", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 11, PublisherName = "Metis Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 12, PublisherName = "İthaki Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 13, PublisherName = "Doğan Egmont", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 14, PublisherName = "Tudem Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 15, PublisherName = "Türkiye İş Bankası Kültür Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 16, PublisherName = "Omega Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 17, PublisherName = "Kalem Kitap", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 18, PublisherName = "Beyaz Balina Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 19, PublisherName = "Profil Yayıncılık", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Publisher {Id = 20, PublisherName = "Dergah Yayınları", CreatedAt = DateTime.Now, Status = Enums.Status.Added }
            );

        }
    }
}
