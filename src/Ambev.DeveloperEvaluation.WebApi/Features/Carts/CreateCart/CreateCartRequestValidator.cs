using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    /// <summary>
    /// Validador para a requisição de criação de carrinho.
    /// </summary>
	public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("O ID do usuário é obrigatório.");
            RuleFor(x => x.Products).NotEmpty().WithMessage("O carrinho não pode estar vazio.");
            RuleForEach(x => x.Products).SetValidator(new CartProductRequestValidator());
        }
    }

    /// <summary>
    /// Validador para os itens do produto na requisição.
    /// </summary>
    public class CartProductRequestValidator : AbstractValidator<CartProductRequest>
    {
        public CartProductRequestValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}