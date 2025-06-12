using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartResponse
    {

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public List<CartProductResponse> Products { get; set; } = new();
        public class CartProductResponse
        {
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}