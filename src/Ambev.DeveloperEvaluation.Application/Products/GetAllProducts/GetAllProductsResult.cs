
using Ambev.DeveloperEvaluation.Application.Common.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

public class GetAllProductsResult
{
    public IEnumerable<ProductDto> Data { get; init; } = Enumerable.Empty<ProductDto>();
    public int Page { get; init; }
    public int Limit { get; init; }
    public int TotalPages { get; init; }
}