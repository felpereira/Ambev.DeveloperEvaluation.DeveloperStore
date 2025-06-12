
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;


public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
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
            .WithMessage("A URL da imagem do produto é obrigatória e deve ser válida.");

        RuleFor(x => x.Rating)
            .NotNull()
            .SetValidator(new ProductRatingDtoValidator());
    }
}

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