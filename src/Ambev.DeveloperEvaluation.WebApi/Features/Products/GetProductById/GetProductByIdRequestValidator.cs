using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductById;

public class GetProductByIdRequestValidator : AbstractValidator<GetProductsByIdRequest>
{
    public GetProductByIdRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O Id do produto deve ser informado.");
    }
}
