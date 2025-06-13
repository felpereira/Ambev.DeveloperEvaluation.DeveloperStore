using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts
{
    public class GetAllCartsQueryValidator : AbstractValidator<GetAllCartsQuery>
    {
        public GetAllCartsQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0);
            RuleFor(x => x.Size).GreaterThan(0);
        }
    }
}

