using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
    {
        public UpdateCartRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID do carrinho na rota é obrigatório.")
                .NotEqual(Guid.Empty);

            RuleForEach(x => x.Items).SetValidator(new CartItemUpdateRequestValidator());
        }
    }

    public class CartItemUpdateRequestValidator : AbstractValidator<CartItemUpdateRequest>
    {
        public CartItemUpdateRequestValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}
