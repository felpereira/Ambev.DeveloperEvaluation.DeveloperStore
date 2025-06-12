using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.ProductId).IsRequired();
            builder.Property(ci => ci.Quantity).IsRequired();

            builder.Property(p => p.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Discount)
                .IsRequired()
                .HasColumnType("decimal(3,2)");
        }
    }
}
