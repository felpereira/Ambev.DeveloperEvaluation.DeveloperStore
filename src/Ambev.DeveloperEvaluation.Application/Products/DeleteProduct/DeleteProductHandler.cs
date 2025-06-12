using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Common.Exceptions;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;


public class DeleteProductHandler(IProductRepository repository)
    : IRequestHandler<DeleteProductCommand, DeleteProductResult>
{
    private readonly IProductRepository _repository = repository;

    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var productExists = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (productExists is null)
        {
            throw new NotFoundException($"Produto com o Id {request.Id} não foi encontrado.");
        }

        var result = await _repository.DeleteAsync(productExists);

        return new DeleteProductResult
        {
            Message = result ? "Produto excluído com sucesso." : "Ocorreu um erro ao excluir o produto."
        };
    }
}