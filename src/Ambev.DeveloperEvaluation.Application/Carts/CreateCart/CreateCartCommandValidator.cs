using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty();
            RuleFor(v => v.Products).NotEmpty();
            RuleForEach(v => v.Products).SetValidator(new CartItemCommandValidator());
        }
    }

    public class CartItemCommandValidator : AbstractValidator<CartItemCommand>
    {
        public CartItemCommandValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.Quantity).GreaterThan(0);
        }
    }
}
