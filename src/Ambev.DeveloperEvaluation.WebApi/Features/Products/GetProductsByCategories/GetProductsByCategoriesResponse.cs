using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategories;

public record GetProductsByCategoriesResponse
{
    public IEnumerable<ProductDto> Data { get; init; } = Enumerable.Empty<ProductDto>();
    public int Page { get; init; }
    public int Limit { get; init; }
    public int TotalPages { get; init; }
}
