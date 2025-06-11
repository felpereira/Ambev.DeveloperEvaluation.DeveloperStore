using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;


public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
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

        RuleFor(x => x.Rating)
            .NotNull()
            .SetValidator(new ProductRatingDtoValidator());
    }
}

/// <summary>
/// Validador para o DTO de avaliação de produto.
/// Esta classe é reutilizada por outros validadores.
/// </summary>
public class ProductRatingDtoValidator : AbstractValidator<ProductRatingDto>
{
    public ProductRatingDtoValidator()
    {
        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 5)
            .WithMessage("A avaliação deve estar entre 0 e 5.");

        RuleFor(x => x.Count)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A contagem de avaliações não pode ser negativa.");
    }
}
