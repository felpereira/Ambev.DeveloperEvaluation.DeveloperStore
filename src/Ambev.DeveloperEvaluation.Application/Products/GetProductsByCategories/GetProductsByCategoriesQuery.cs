using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategories;


public record GetProductsByCategoriesQuery(string Category, int? Page, int? Limit)
    : IRequest<GetProductsByCategoriesResult>;