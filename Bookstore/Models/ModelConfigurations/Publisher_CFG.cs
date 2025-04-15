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
                new Publisher { Id = 1, PublisherName = "Pegasus Yayınları" },
                new Publisher { Id = 2, PublisherName = "Can Yayınları" },
                new Publisher { Id = 3, PublisherName = "İş Bankası Kültür Yayınları" },
                new Publisher { Id = 4, PublisherName = "Altın Kitaplar" },
                new Publisher { Id = 5, PublisherName = "YKY" },
                new Publisher { Id = 6, PublisherName = "Epsilon Yayınları" },
                new Publisher { Id = 7, PublisherName = "Remzi Kitabevi" },
                new Publisher { Id = 8, PublisherName = "Everest Yayınları" },
                new Publisher { Id = 9, PublisherName = "Doğan Kitap" },
                new Publisher { Id = 10, PublisherName = "Kafka Kitap" }
            );

        }
    }
}
