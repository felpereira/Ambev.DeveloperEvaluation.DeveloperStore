using Ambev.DeveloperEvaluation.Application.Common.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductById;

public class GetProductsByIdHandler(IProductRepository repository, IMapper mapper)
    : IRequestHandler<GetProductsByIdQuery, GetProductsByIdResult>
{
    public async Task<GetProductsByIdResult> Handle(GetProductsByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(query.Id, cancellationToken);

        if (product is null)
        {
            throw new NotFoundException("Produto", query.Id);
        }
        return mapper.Map<GetProductsByIdResult>(product);
    }
}
