using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart
{
    /// <summary>
    /// Validador para a requisição de exclusão de carrinho.
    /// </summary>
    public class DeleteCartRequestValidator : AbstractValidator<DeleteCartRequest>
    {
        public DeleteCartRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID do carrinho deve ser informado.")
                .NotEqual(Guid.Empty).WithMessage("O ID do carrinho não pode ser um Guid vazio.");
        }
    }
}
