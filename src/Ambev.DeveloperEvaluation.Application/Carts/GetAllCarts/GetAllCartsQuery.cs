using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts
{
    public class GetAllCartsQuery : IRequest<GetAllCartsResult>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
