using Ambev.DeveloperEvaluation.Application.Common.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Unit = MediatR.Unit;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart
{
    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, Unit>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);
            if (cart == null)
                throw new NotFoundException("Cart not found.");

            await _cartRepository.DeleteAsync(cart, cancellationToken);
            return Unit.Value;
        }
    }
}
