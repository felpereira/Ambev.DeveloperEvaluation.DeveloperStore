using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategories;


public class GetProductsByCategoriesQueryValidator : AbstractValidator<GetProductsByCategoriesQuery>
{
    public GetProductsByCategoriesQueryValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("A categoria deve ser informada.");

        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage("O número da página deve ser maior ou igual a 1.");

        RuleFor(x => x.Limit)
            .GreaterThanOrEqualTo(1)
            .WithMessage("O limite de itens por página deve ser maior ou igual a 1.");
    }
}