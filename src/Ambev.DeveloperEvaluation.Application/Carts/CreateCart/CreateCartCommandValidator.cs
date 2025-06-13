using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidator()
        {
            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("O ID do usuário é obrigatório.");

            RuleFor(v => v.Products)
                .NotEmpty().WithMessage("A lista de produtos não pode ser vazia.");

            RuleForEach(v => v.Products)
                .SetValidator(new CreateCartItemDtoValidator());
        }
    }

    public class CreateCartItemDtoValidator : AbstractValidator<CreateCartItemDto>
    {
        public CreateCartItemDtoValidator()
        {
            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("O ID do produto é obrigatório.");

            RuleFor(p => p.Quantity)
                .GreaterThan(0).WithMessage("A quantidade do produto deve ser maior que zero.");
        }
    }
}
