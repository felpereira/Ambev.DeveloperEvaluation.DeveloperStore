using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

public record GetAllProductsQuery(int? Page, int? Limit) : IRequest<GetAllProductsResult>;