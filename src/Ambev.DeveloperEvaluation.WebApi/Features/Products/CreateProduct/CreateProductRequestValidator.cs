using Ambev.DeveloperEvaluation.Application.Common; // Para o ProductRatingDtoValidator
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;


public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
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

        RuleFor(x => x.Image)
            .NotEmpty()
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("A URL da imagem do produto é obrigatória e deve ser válida.");
    }
}