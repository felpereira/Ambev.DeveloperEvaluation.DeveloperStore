using Ambev.DeveloperEvaluation.Domain.Common;
using System.Diagnostics.CodeAnalysis; // 1. Adicionar este using

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class CartItem : Entity<Guid>
    {
        public Guid CartId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }

        public virtual Cart? Cart { get; private set; }

        private CartItem() { }

        [SetsRequiredMembers] // 2. Adicionar este atributo
        private CartItem(Guid productId, int quantity, decimal unitPrice)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = 0;
        }

        public static CartItem Create(Guid productId, int quantity, decimal unitPrice)
        {
            return new CartItem(productId, quantity, unitPrice);
        }

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }

        public void ApplyDiscount(decimal discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 1)
                throw new ArgumentException("O percentual de desconto deve estar entre 0 e 1.", nameof(discountPercentage));

            Discount = discountPercentage;
        }
    }
}