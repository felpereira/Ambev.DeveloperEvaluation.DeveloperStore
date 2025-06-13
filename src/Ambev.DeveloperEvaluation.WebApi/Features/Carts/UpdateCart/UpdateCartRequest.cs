using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{

    public class UpdateCartRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public List<CartItemUpdateRequest> Items { get; set; } = [];
    }

    public class CartItemUpdateRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
