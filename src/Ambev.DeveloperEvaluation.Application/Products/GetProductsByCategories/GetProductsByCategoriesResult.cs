using Ambev.DeveloperEvaluation.Application.Common.DTOs; // Importe o namespace do DTO

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategories;


public class GetProductsByCategoriesResult
{

    public IEnumerable<ProductDto> Data { get; init; } = Enumerable.Empty<ProductDto>();


    public int Page { get; init; }


    public int Limit { get; init; }


    public int TotalPages { get; init; }
}