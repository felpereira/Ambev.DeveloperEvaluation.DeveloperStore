using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategories;


public class GetProductsByCategoriesHandler(IProductRepository repository, IMapper mapper)
    : IRequestHandler<GetProductsByCategoriesQuery, GetProductsByCategoriesResult>
{
    public async Task<GetProductsByCategoriesResult> Handle(GetProductsByCategoriesQuery request, CancellationToken cancellationToken)
    {
        int page = request.Page ?? 1;
        int limit = request.Limit ?? 10;

        var productEntities = await repository.GetByCategoryAsync(request.Category, page, limit, cancellationToken);
        var totalPages = await repository.GetCountByCategoryAsync(request.Category, cancellationToken) / limit;

        var productDtos = mapper.Map<IEnumerable<ProductDto>>(productEntities);

        return new GetProductsByCategoriesResult
        {
            Limit = limit,
            TotalPages = totalPages,
            Page = page,
            Data = productDtos
        };
    }
}