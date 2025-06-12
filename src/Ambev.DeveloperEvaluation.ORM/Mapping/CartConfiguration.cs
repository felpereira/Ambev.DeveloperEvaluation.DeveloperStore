using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.UserId).IsUnique();
            builder.Property(c => c.Date).IsRequired();

            builder.HasMany(c => c.Items)
                   .WithOne(ci => ci.Cart)
                   .HasForeignKey(ci => ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Garante que os itens do carrinho sejam sempre carregados automaticamente nas consultas.
            builder.Navigation(c => c.Items).AutoInclude();
        }
    }
}