using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public record UpdateCartCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int UserId { get; init; }
        public List<CartItemCommand> Products { get; init; } = new();
    }

    public record CartItemCommand(
        Guid ProductId,
        int Quantity);
}