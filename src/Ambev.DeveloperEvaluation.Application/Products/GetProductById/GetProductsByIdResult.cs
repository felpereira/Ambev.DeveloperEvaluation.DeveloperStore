using Ambev.DeveloperEvaluation.Application.Common.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductById;


public class GetProductsByIdResult
{
    public Guid Id { get; init; }
    public decimal Price { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string Category { get; init; } = default!;
    public string Image { get; init; } = default!;
    public ProductRatingDto Rating { get; init; } = default!;
}