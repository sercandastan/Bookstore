using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class Order_CFG : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Order → AppUser (1:N)
            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Order → OrderItem (1:N)
            builder.HasMany(o => o.Items)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.OrderDate).IsRequired();

            builder.Property(o => o.OrderStatus)
                .HasConversion<string>()
                .IsRequired();



        }
    }
}
