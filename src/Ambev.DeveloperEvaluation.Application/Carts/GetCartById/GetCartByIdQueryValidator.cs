using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById
{
    public class GetCartByIdQueryValidator : AbstractValidator<GetCartByIdQuery>
    {
        public GetCartByIdQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
