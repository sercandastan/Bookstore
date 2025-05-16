using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models.ModelConfigurations
{
    public class OrderItem_CFG : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(oi => oi.Book)
       .WithMany(b => b.OrderItems)
       .HasForeignKey(oi => oi.BookId)
       .OnDelete(DeleteBehavior.Restrict);

            builder.Property(oi => oi.Quantity).IsRequired();

            builder.Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();

        }
    }
}
