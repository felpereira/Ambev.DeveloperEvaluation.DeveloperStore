using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;


public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id do produto é obrigatório para a atualização.");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("O título do produto é obrigatório.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("O preço do produto deve ser um valor válido e maior que zero.");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("A categoria do produto é obrigatória.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("A descrição do produto é obrigatória.");


        RuleFor(x => x.Rating)
            .NotNull()
            .SetValidator(new ProductRatingDtoValidator());
    }
}