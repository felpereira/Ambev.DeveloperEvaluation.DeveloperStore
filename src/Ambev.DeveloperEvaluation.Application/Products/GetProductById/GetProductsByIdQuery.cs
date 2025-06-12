using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductById;

public record GetProductsByIdQuery(Guid Id) : IRequest<GetProductsByIdResult>;