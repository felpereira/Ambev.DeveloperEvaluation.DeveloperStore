using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;


public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
{
    public DeleteProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O Id do produto é obrigatório para a exclusão.");
    }
}
