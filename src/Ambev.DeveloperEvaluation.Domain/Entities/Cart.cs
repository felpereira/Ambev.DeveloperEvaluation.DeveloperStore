using Ambev.DeveloperEvaluation.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }

        // private readonly List<CartItem> _items = [];
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
        // Construtor para o EF Core.
        private Cart() { }

        [SetsRequiredMembers]
        private Cart(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            // Date = DateTime.UtcNow;
        }

        public static Cart Create(Guid userId)
        {
            return new Cart(userId);
        }

        public void AddItem(Product product, int quantity)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));

            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            int newQuantity = quantity; 

            if (existingItem != null)
            {
                newQuantity = existingItem.Quantity;
            }

            ValidateItemQuantity(newQuantity);

            if (existingItem != null)
            {
                existingItem.UpdateQuantity(newQuantity);
                ApplyBusinessRules(existingItem);
            }
            else
            {
                var newItem = CartItem.Create(product.Id, quantity, product.Price, Guid.Empty);
                ApplyBusinessRules(newItem);
                Items.Add(newItem);
            }

        }

        public void ClearItems()
        {
            Items.Clear();
        }

        public void UpdateItem(Guid productId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
                throw new KeyNotFoundException("Produto não encontrado no carrinho.");

            ValidateItemQuantity(quantity);

            if (quantity == 0)
            {
                Items.Remove(item);
            }
            else
            {
                item.UpdateQuantity(quantity);
                ApplyBusinessRules(item);
            }

            // Date = DateTime.UtcNow;
        }

        public void RemoveItem(Guid productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
                // Date = DateTime.UtcNow;
            }
        }

        private static void ValidateItemQuantity(int quantity)
        {
            if (quantity > 20)
                throw new DomainException("Não é possível ter mais de 20 itens idênticos no carrinho.");

            if (quantity < 0)
                throw new DomainException("A quantidade do item não pode ser negativa.");
        }

        private static void ApplyBusinessRules(CartItem item)
        {
            if (item.Quantity >= 10 && item.Quantity <= 20)
            {
                item.ApplyDiscount(0.20m); // 20% de desconto.
            }
            else if (item.Quantity >= 4 && item.Quantity < 10)
            {
                item.ApplyDiscount(0.10m); // 10% de desconto.
            }
            else
            {
                item.ApplyDiscount(0m); // Sem desconto.
            }
        }

        public decimal GetTotalAmount()
        {
            return Items.Sum(item =>
                (item.Quantity * item.UnitPrice) * (1 - item.Discount)
            );
        }
    }
}