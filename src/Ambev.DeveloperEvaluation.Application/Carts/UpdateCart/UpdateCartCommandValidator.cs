using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
            RuleFor(v => v.UserId).NotEmpty();
            RuleFor(v => v.Products).NotNull();
        }
    }
}
