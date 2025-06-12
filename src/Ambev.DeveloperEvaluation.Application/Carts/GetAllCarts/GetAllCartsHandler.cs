using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts
{
    public class GetAllCartsHandler : IRequestHandler<GetAllCartsQuery, GetAllCartsResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetAllCartsHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<GetAllCartsResult> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            var carts = await _cartRepository.GetAllAsync(request.Page, request.Size, cancellationToken);
            var cartDtos = _mapper.Map<List<CartDto>>(carts);

            return new GetAllCartsResult
            {
                Data = cartDtos,
                TotalItems = carts.Count(),
                CurrentPage = request.Page,
                PageSize = request.Size,
                TotalPages = (int)Math.Ceiling(carts.Count() / (double)request.Size)
            };
        }
    }
}
