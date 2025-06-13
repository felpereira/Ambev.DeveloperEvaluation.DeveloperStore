using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartsByUserId
{
    public class GetCartsByUserIdQueryValidator : AbstractValidator<GetCartsByUserIdQuery>
    {
        public GetCartsByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
