using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class Book_CFG : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(b => b.Price).HasColumnType("money").IsRequired();
            builder.Property(b => b.PublicationYear).HasColumnType("smallint").IsRequired();
            builder.Property(b => b.EditionNumber).HasColumnType("int").IsRequired();
            builder.Property(b => b.CoverText).HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            builder.Property(b => b.CoverImage).HasColumnType("varchar").HasMaxLength(256).IsRequired(false);
            builder.Property(b => b.Status).HasConversion<string>();
            builder.Property(b => b.CategoryId).IsRequired();
            builder.Property(b => b.PublisherId).IsRequired();
            builder.Property(b => b.UserId).IsRequired();

            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "Gece Yarısı Kütüphanesi",
                    Price = 120,
                    EditionNumber = 1,
                    PublicationYear = 2020,
                    CategoryId = 8,
                    PublisherId = 1,
                    CoverText = "Hayatın olasılıkları üzerine etkileyici bir hikaye.",
                    CoverImage = "/BookCoverImages/gyk.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,

                },
                new Book
                {
                    Id = 2,
                    Title = "1984",
                    Price = 90,
                    EditionNumber = 5,
                    PublicationYear = 1949,
                    CategoryId = 2,
                    PublisherId = 2,
                    CoverText = "Distopik bir geleceğin sert tasviri.",
                    CoverImage = "/BookCoverImages/1984.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 3,
                    Title = "Aşk ve Gurur",
                    Price = 85,
                    EditionNumber = 3,
                    PublicationYear = 1813,
                    CategoryId = 6,
                    PublisherId = 3,
                    CoverText = "Zarafet ve sınıf çatışmalarının romanı.",
                    CoverImage = "/BookCoverImages/avg.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 4,
                    Title = "O",
                    Price = 110,
                    EditionNumber = 2,
                    PublicationYear = 1986,
                    CategoryId = 3,
                    PublisherId = 4,
                    CoverText = "Korku dolu bir kasaba ve geçmişin karanlığı.",
                    CoverImage = "/BookCoverImages/O.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 5,
                    Title = "Harry Potter ve Felsefe Taşı",
                    Price = 100,
                    EditionNumber = 1,
                    PublicationYear = 1997,
                    CategoryId = 7,
                    PublisherId = 5,
                    CoverText = "Büyücü bir çocuğun destansı yolculuğu.",
                    CoverImage = "/BookCoverImages/hpvft.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 6,
                    Title = "On Küçük Zenci",
                    Price = 95,
                    EditionNumber = 4,
                    PublicationYear = 1939,
                    CategoryId = 5,
                    PublisherId = 6,
                    CoverText = "Gerilim ve gizemin en iyi örneklerinden.",
                    CoverImage = "/BookCoverImages/okz.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 7,
                    Title = "Savaş ve Barış",
                    Price = 130,
                    EditionNumber = 2,
                    PublicationYear = 1869,
                    CategoryId = 9,
                    PublisherId = 7,
                    CoverText = "Rusya'nın tarihsel ve kültürel panoraması.",
                    CoverImage = "/BookCoverImages/svb.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 8,
                    Title = "Yaşlı Adam ve Deniz",
                    Price = 80,
                    EditionNumber = 2,
                    PublicationYear = 1952,
                    CategoryId = 1,
                    PublisherId = 8,
                    CoverText = "Direnişin ve yalnızlığın metaforu.",
                    CoverImage = "/BookCoverImages/yavd.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 9,
                    Title = "1Q84",
                    Price = 125,
                    EditionNumber = 1,
                    PublicationYear = 2009,
                    CategoryId = 2,
                    PublisherId = 9,
                    CoverText = "Paralel evrende geçen gizemli bir yolculuk.",
                    CoverImage = "/BookCoverImages/1q84.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 10,
                    Title = "Yüzyıllık Yalnızlık",
                    Price = 115,
                    EditionNumber = 3,
                    PublicationYear = 1967,
                    CategoryId = 10,
                    PublisherId = 10,
                    CoverText = "Bir ailenin kuşaklar arası büyülü hikayesi.",
                    CoverImage = "/BookCoverImages/yy.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 11,
                    Title = "Körlük",

                    Price = 105,
                    EditionNumber = 2,
                    PublicationYear = 1995,
                    CategoryId = 3,
                    PublisherId = 11,
                    CoverText = "Toplumsal çöküşün karanlık portresi.",
                    CoverImage = "/BookCoverImages/korluk.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 12,
                    Title = "Masumiyet Müzesi",

                    Price = 95,
                    EditionNumber = 1,
                    PublicationYear = 2008,
                    CategoryId = 10,
                    PublisherId = 12,
                    CoverText = "Takıntı ile aşkın sınırlarında bir hikaye.",
                    CoverImage = "/BookCoverImages/masumiyet.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 13,
                    Title = "Suç ve Ceza",

                    Price = 110,
                    EditionNumber = 3,
                    PublicationYear = 1866,
                    CategoryId = 6,
                    PublisherId = 13,
                    CoverText = "Vicdan azabının psikolojik çözümlemesi.",
                    CoverImage = "/BookCoverImages/scuzceza.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 14,
                    Title = "Kayıp Zamanın İzinde",
                    Price = 150,
                    EditionNumber = 1,
                    PublicationYear = 1913,
                    CategoryId = 8,
                    PublisherId = 14,
                    CoverText = "Belleğin ince notaları.",
                    CoverImage = "/BookCoverImages/kayipzaman.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 15,
                    Title = "Mrs Dalloway",
                    Price = 90,
                    EditionNumber = 2,
                    PublicationYear = 1925,
                    CategoryId = 4,
                    PublisherId = 15,
                    CoverText = "Bir günün özenle işlenmiş portresi.",
                    CoverImage = "/BookCoverImages/mrsdalloway.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 16,
                    Title = "Siddhartha",
                    Price = 85,
                    EditionNumber = 1,
                    PublicationYear = 1922,
                    CategoryId = 4,
                    PublisherId = 16,
                    CoverText = "Ruhani yolculuğa dair bir başyapıt.",
                    CoverImage = "/BookCoverImages/siddhartha.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 17,
                    Title = "Tom Sawyer’ın Maceraları",
                    Price = 75,
                    EditionNumber = 5,
                    PublicationYear = 1876,
                    CategoryId = 1,
                    PublisherId = 17,
                    CoverText = "Çocukluğun neşeli dünyası.",
                    CoverImage = "/BookCoverImages/tomsawyer.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 18,
                    Title = "Dönüşüm",
                    Price = 80,
                    EditionNumber = 1,
                    PublicationYear = 1915,
                    CategoryId = 3,
                    PublisherId = 18,
                    CoverText = "Varoluşsal kaygının sembolik öyküsü.",
                    CoverImage = "/BookCoverImages/donusum.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 19,
                    Title = "Simyacı",
                    Price = 95,
                    EditionNumber = 3,
                    PublicationYear = 1988,
                    CategoryId = 7,
                    PublisherId = 19,
                    CoverText = "Rüyanın peşinde bir yolculuk.",
                    CoverImage = "/BookCoverImages/simyaci.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Book
                {
                    Id = 20,
                    Title = "Da Vinci Şifresi",
                    Price = 120,
                    EditionNumber = 2,
                    PublicationYear = 2003,
                    CategoryId = 2,
                    PublisherId = 20,
                    CoverText = "Tarih, sanat ve gizemin kesiştiği nokta.",
                    CoverImage = "/BookCoverImages/davinci.jpg",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                }
            );



        }
    }
}
