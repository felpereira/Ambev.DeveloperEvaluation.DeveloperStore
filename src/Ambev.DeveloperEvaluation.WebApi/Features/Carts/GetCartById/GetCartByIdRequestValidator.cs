using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById
{

    public class GetCartByIdRequestValidator : AbstractValidator<GetCartByIdRequest>
    {
        public GetCartByIdRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID do carrinho é obrigatório.")
                .NotEqual(Guid.Empty).WithMessage("O ID do carrinho fornecido não é válido.");
        }
    }
}
