
using Ambev.DeveloperEvaluation.Domain.Entities; // Onde a entidade Product está
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductHandler(IProductRepository repository, IMapper mapper)
    : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = _mapper.Map<Product>(request);

        var createdProduct = await _repository.AddAsync(product, cancellationToken);

        return _mapper.Map<CreateProductResult>(createdProduct);
    }
}