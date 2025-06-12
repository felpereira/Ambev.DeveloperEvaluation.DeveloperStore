using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;
using Ambev.DeveloperEvaluation.Application.Products.GetCategories;
using Ambev.DeveloperEvaluation.Application.Products.GetProductById;
using Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategories;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductById;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;


[Route("api/[controller]")]
[ApiController]
public class ProductController(IMapper mapper, ISender sender) : ControllerBase
{

    private readonly IMapper _mapper = mapper;
    private readonly ISender _sender = sender;

    [HttpPost]
    // [Authorize] // Garante que apenas usuários autenticados podem acessar este endpoint.
    [ProducesResponseType(typeof(CreateProductResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateProductCommand>(request);

        var result = await _sender.Send(command, cancellationToken);

        var response = _mapper.Map<CreateProductResponse>(result);

        return Created($"/api/products/{response.Id}", response);
    }

    [HttpGet]
    // [Authorize]
    [ProducesResponseType(typeof(GetAllProductsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var query = _mapper.Map<GetAllProductsQuery>(request);

        var result = await _sender.Send(query, cancellationToken);

        var response = _mapper.Map<GetAllProductsResponse>(result);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    // [Authorize]
    [ProducesResponseType(typeof(DeleteProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        var response = _mapper.Map<DeleteProductResponse>(result);

        return Ok(response);
    }


    [HttpGet("categories")]
    // [Authorize]
    [ProducesResponseType(typeof(GetCategoriesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
    {
        var query = new GetCategoriesQuery();

        var result = await _sender.Send(query, cancellationToken);

        var response = _mapper.Map<GetCategoriesResponse>(result);

        return Ok(response);
    }


    [HttpGet("{id:guid}")]
    // [Authorize]
    [ProducesResponseType(typeof(GetProductsByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductsByIdQuery(id);
        var result = await _sender.Send(query, cancellationToken);
        var response = _mapper.Map<GetProductsByIdResponse>(result);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    // [Authorize]
    [ProducesResponseType(typeof(UpdateProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateProductCommand>(request) with { Id = id };

        var result = await _sender.Send(command, cancellationToken);
        var response = _mapper.Map<UpdateProductResponse>(result);
        return Ok(response);
    }

    [HttpGet("categories/{category}")]
    // [Authorize]
    [ProducesResponseType(typeof(GetProductsByCategoriesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductsByCategories([FromRoute] string category, [FromQuery] GetProductsByCategoriesRequest pagination, CancellationToken cancellationToken)
    {
        var query = new GetProductsByCategoriesQuery(category, pagination.Page, pagination.Limit);
        var result = await _sender.Send(query, cancellationToken);
        var response = _mapper.Map<GetProductsByCategoriesResponse>(result);
        return Ok(response);
    }
}
