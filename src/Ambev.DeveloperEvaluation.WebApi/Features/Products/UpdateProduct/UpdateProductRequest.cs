using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public record UpdateProductRequest
{
    public decimal Price { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string Category { get; init; } = default!;
    public string Image { get; init; } = default!;
    public ProductRatingDto Rating { get; init; } = default!;
}
