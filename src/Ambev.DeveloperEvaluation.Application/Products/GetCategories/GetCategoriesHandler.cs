using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetCategories;

public class GetCategoriesHandler(IProductRepository repository)
    : IRequestHandler<GetCategoriesQuery, GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categoriesEnumerable = await repository.GetCategoriesAsync(cancellationToken);

        return new GetCategoriesResult(categoriesEnumerable.ToList());
    }
}