using MediatR;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartCommand : IRequest<CreateCartResult>
    {
        public Guid UserId { get; set; }
        public List<CreateCartItemDto> Products { get; set; } = new();
    }

    public class CreateCartItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}