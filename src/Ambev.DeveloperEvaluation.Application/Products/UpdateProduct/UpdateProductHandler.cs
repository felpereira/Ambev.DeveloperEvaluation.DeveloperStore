using Ambev.DeveloperEvaluation.Application.Common.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductHandler(IProductRepository repository, IMapper mapper)
    : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productToUpdate = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (productToUpdate is null)
        {
            throw new NotFoundException("Produto", request.Id);
        }

        mapper.Map(request, productToUpdate);

        await repository.UpdateAsync(productToUpdate);

        return mapper.Map<UpdateProductResult>(productToUpdate);
    }
}