namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategories;

/// <summary>
/// Representa a requisição (request) para buscar produtos por categoria, com paginação.
/// </summary>
/// <param name="Category">A categoria a ser buscada, vinda da rota.</param>
/// <param name="Page">O número da página a ser retornada.</param>
/// <param name="Limit">A quantidade de itens por página.</param>
public record GetProductsByCategoriesRequest
{
    // A Categoria virá da rota, então não é necessária como propriedade aqui.
    // Os parâmetros de paginação vêm da query string.
    public int? Page { get; init; }
    public int? Limit { get; init; }
};
