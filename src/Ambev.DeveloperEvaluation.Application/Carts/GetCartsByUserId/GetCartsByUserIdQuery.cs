using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartsByUserId
{
    public class GetCartsByUserIdQuery : IRequest<List<CartDto>>
    {
        public Guid UserId { get; set; }
    }
}
