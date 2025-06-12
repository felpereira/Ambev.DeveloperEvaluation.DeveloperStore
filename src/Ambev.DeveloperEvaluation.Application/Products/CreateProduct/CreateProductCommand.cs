
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public record CreateProductCommand(
    decimal Price,
    string Title,
    string Description,
    string Category,
    string Image,
    ProductRatingDto Rating) : IRequest<CreateProductResult>;