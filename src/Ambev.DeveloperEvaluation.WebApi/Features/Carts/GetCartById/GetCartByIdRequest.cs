using Microsoft.AspNetCore.Mvc;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById
{
    public class GetCartByIdRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}
