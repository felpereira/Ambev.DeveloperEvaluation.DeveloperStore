using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;

public class GetAllProductsValidator : AbstractValidator<GetAllProductsRequest>
{
    public GetAllProductsValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage("O número da página deve ser maior ou igual a 1.");

        RuleFor(x => x.Limit)
            .GreaterThanOrEqualTo(1)
            .WithMessage("O limite de itens por página deve ser maior ou igual a 1.");
    }
}
