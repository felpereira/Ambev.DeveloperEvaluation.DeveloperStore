using Ambev.DeveloperEvaluation.Application.Common.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Unit = MediatR.Unit;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, Unit>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public UpdateCartHandler(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);

            if (cart == null)
                throw new NotFoundException("Cart not found.");

            foreach (var item in request.Products)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);
                if (product == null)
                    throw new NotFoundException($"Product with ID {item.ProductId} not found.");

                cart.AddItem(product, item.Quantity);
            }

            await _cartRepository.UpdateAsync(cart, cancellationToken);

            return Unit.Value;
        }
    }
}