using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequest
    {
        public Guid UserId { get; set; }

        public List<CartProductRequest> Products { get; set; } = [];
    }


    public class CartProductRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}