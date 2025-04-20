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
                new Category { Id = 1, CategoryName = "Roman",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Category { Id = 2, CategoryName = "Bilim Kurgu",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Category { Id = 3, CategoryName = "Korku",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Category { Id = 4, CategoryName = "Felsefe",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Category { Id = 5, CategoryName = "Polisiye",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Category { Id = 6, CategoryName = "Klasik",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Category { Id = 7, CategoryName = "Fantastik",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Category { Id = 8, CategoryName = "Modern Edebiyat",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Category { Id = 9, CategoryName = "Tarih",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Category { Id = 10, CategoryName = "Latin Amerika Edebiyatı",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added,
                },
                new Category { Id = 11, CategoryName = "Çocuk",
                    CreatedAt = DateTime.Now,
                    Status = Enums.Status.Added
                },
                new Category {Id = 12, CategoryName = "Psikoloji", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Category {Id = 13, CategoryName = "Kişisel Gelişim", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Category {Id = 14, CategoryName = "Biyografi", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Category {Id = 15, CategoryName = "Gezi", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Category {Id = 16, CategoryName = "Sağlık", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Category {Id = 17, CategoryName = "Ekonomi", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Category {Id = 18, CategoryName = "Sanat", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Category {Id = 19, CategoryName = "Şiir", CreatedAt = DateTime.Now, Status = Enums.Status.Added },
                new Category {Id = 20, CategoryName = "Çağdaş Dünya Edebiyatı", CreatedAt = DateTime.Now, Status = Enums.Status.Added }
            );


        }
    }
}
