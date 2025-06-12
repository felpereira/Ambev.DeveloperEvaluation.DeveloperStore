using Ambev.DeveloperEvaluation.Application.Common.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;


public record CreateProductRequest(
    decimal Price,
    string Title,
    string Description,
    string Category,
    string Image,
    ProductRatingDto Rating
);