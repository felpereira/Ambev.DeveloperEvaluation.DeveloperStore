namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategories;

public record GetProductsByCategoriesRequest
{
    public int? Page { get; init; }
    public int? Limit { get; init; }
};
