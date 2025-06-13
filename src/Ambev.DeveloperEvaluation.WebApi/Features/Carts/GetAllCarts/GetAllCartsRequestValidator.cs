using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts
{
    /// <summary>
    /// Validador para a requisição de busca paginada de carrinhos.
    /// </summary>
    public class GetAllCartsRequestValidator : AbstractValidator<GetAllCartsRequest>
    {
        public GetAllCartsRequestValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1).WithMessage("O número da página deve ser maior ou igual a 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("O tamanho da página deve ser maior ou igual a 1.");
        }
    }
}
