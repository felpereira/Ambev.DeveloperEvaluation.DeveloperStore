using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartsByUserId
{
    public class GetCartsByUserIdHandler : IRequestHandler<GetCartsByUserIdQuery, List<CartDto>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartsByUserIdHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<List<CartDto>> Handle(GetCartsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var carts = await _cartRepository.GetByUserIdAsync(request.UserId, cancellationToken);
            return _mapper.Map<List<CartDto>>(carts);
        }
    }
}
