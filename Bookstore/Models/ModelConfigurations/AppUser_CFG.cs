using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class AppUser_CFG : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            AppUser admin = new AppUser()
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
                EmailConfirmed = false,
                



            };

            AppUser user = new AppUser()
            {
                Id = 2,
                Name = "Sercan",
                Surname = "Daştan",
                UserName = "sercandastan",
                NormalizedUserName = "SERCANDASTAN",
                Email = "sercandastan@hotmail.com",
                NormalizedEmail = "SERCANDASTAN@HOTMAIL.COM",
                Gender = Enums.Gender.Male,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false

            };

            //Password Hash'leme
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin_123");
            user.PasswordHash = passwordHasher.HashPassword(user, "Sercan_123");
            builder.HasData(admin,user);

            
        }
    }
}
