using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById
{
    public class GetCartByIdQuery : IRequest<CartDto>
    {
        public Guid Id { get; set; }

        public GetCartByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
