using Ambev.DeveloperEvaluation.Application.Common.DTOs; // Importe o namespace do seu ProductDto
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;

/// <summary>
/// Representa a resposta da API com a lista paginada de produtos.
/// </summary>
public record GetAllProductsResponse
{
    /// <summary>
    /// A lista de produtos na página atual.
    /// </summary>
    public IEnumerable<ProductDto> Data { get; init; } = Enumerable.Empty<ProductDto>();

    /// <summary>
    /// O número da página atual.
    /// </summary>
    public int Page { get; init; }

    /// <summary>
    /// O limite de itens por página.
    /// </summary>
    public int Limit { get; init; }

    /// <summary>
    /// O número total de páginas disponíveis.
    /// </summary>
    public int TotalPages { get; init; }
}
