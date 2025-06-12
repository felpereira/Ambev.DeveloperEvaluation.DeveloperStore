using Ambev.DeveloperEvaluation.WebApi.Common;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts
{

    public class CartResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public List<CartItemResponse> Items { get; set; } = [];
        public decimal Total { get; set; }
    }


    public class CartItemResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
