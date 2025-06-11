using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategories;

/// <summary>
/// Validador para a requisição de busca de produtos por categoria.
/// Valida apenas os parâmetros de paginação, pois a categoria é parte da rota.
/// </summary>
public class GetProductsByCategoriesRequestValidator : AbstractValidator<GetProductsByCategoriesRequest>
{
    public GetProductsByCategoriesRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage("O número da página deve ser maior ou igual a 1.");

        RuleFor(x => x.Limit)
            .GreaterThanOrEqualTo(1)
            .WithMessage("O limite de itens por página deve ser maior ou igual a 1.");
    }
}
