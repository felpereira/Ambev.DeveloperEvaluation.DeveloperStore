using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;


public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id do produto é obrigatório e deve ser válido.");
    }
}