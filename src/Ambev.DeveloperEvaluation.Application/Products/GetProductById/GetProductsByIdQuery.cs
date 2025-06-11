using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductById;

/// <summary>
/// Query para buscar um produto específico pelo seu identificador único.
/// </summary>
/// <param name="Id">O Id do produto a ser buscado.</param>
public record GetProductsByIdQuery(Guid Id) : IRequest<GetProductsByIdResult>;