namespace Ambev.DeveloperEvaluation.Application.Carts
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}