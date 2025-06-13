using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById
{
    public class GetCartByIdResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public List<CartItemResult> Items { get; set; } = [];
        public decimal Total { get; set; }
    }

    public class CartItemResult
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}