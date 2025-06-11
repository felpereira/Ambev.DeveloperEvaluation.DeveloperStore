// Ambev.DeveloperEvaluation.Application.Products.GetAllProducts/GetAllProductsHandler.cs
using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

public class GetAllProductsHandler(IProductRepository repository, IMapper mapper)
    : IRequestHandler<GetAllProductsQuery, GetAllProductsResult>
{
    public async Task<GetAllProductsResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        int page = request.Page ?? 1;
        int limit = request.Limit ?? 10;

        var productEntities = await repository.GetAllAsync(page, limit, cancellationToken);
        var totalPages = await repository.GetCountAsync(cancellationToken) / limit;

        var productDtos = mapper.Map<IEnumerable<ProductDto>>(productEntities);

        return new GetAllProductsResult
        {
            TotalPages = totalPages,
            Data = productDtos,
            Limit = limit,
            Page = page
        };
    }
}