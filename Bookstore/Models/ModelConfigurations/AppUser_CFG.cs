using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class AppUser_CFG : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            AppUser user = new AppUser()
            {
                Id = 1,
                Name = "Super",
                Surname = "Admin",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                Gender = Enums.Gender.Male,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false

            };

            //Password Hash'leme
            PasswordHasher<AppUser>hasher = new PasswordHasher<AppUser>();
            user.PasswordHash = hasher.HashPassword(user, "admin123");
            builder.HasData(user);
        }
    }
}
