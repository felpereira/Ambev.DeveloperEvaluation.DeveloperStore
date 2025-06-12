using Ambev.DeveloperEvaluation.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : Entity<Guid>
    {
        public Guid UserId { get; private set; }
        public DateTime Date { get; private set; }

        private readonly List<CartItem> _items = [];
        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

        // Construtor para o EF Core.
        private Cart() { }

        [SetsRequiredMembers]
        private Cart(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Date = DateTime.UtcNow;
        }

        public static Cart Create(Guid userId)
        {
            return new Cart(userId);
        }

        public void AddItem(Product product, int quantity)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));

            var existingItem = _items.FirstOrDefault(i => i.ProductId == product.Id);
            int newQuantity = quantity;

            if (existingItem != null)
            {
                newQuantity += existingItem.Quantity;
            }

            ValidateItemQuantity(newQuantity);

            if (existingItem != null)
            {
                existingItem.UpdateQuantity(newQuantity);
                ApplyBusinessRules(existingItem);
            }
            else
            {
                var newItem = CartItem.Create(product.Id, quantity, product.Price);
                ApplyBusinessRules(newItem);
                _items.Add(newItem);
            }
            Date = DateTime.UtcNow;
        }

        public void UpdateItem(Guid productId, int quantity)
        {
            var item = _items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
                throw new KeyNotFoundException("Produto não encontrado no carrinho.");

            ValidateItemQuantity(quantity);

            if (quantity == 0)
            {
                _items.Remove(item);
            }
            else
            {
                item.UpdateQuantity(quantity);
                ApplyBusinessRules(item);
            }

            Date = DateTime.UtcNow;
        }

        public void RemoveItem(Guid productId)
        {
            var item = _items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                _items.Remove(item);
                Date = DateTime.UtcNow;
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
            return _items.Sum(item =>
                (item.Quantity * item.UnitPrice) * (1 - item.Discount)
            );
        }
    }
}