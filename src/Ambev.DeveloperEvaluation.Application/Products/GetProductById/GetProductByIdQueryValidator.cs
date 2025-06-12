// Ambev.DeveloperEvaluation.Application.Products.GetProductById/GetProductByIdQueryValidator.cs
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductById;

/// <summary>
/// Validador para a query GetProductsByIdQuery.
/// </summary>
public class GetProductsByIdQueryValidator : AbstractValidator<GetProductsByIdQuery>
{
    public GetProductsByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O Id do produto não pode ser um Guid vazio.");
    }
}