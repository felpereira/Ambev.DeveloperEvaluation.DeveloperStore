using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;
using Ambev.DeveloperEvaluation.Application.Carts.GetCartById;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
// Outros usings para Get, Update, Delete seriam adicionados aqui.

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public CartsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateCartResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateCartCommand>(request);
            var result = await _sender.Send(command, cancellationToken);
            var response = _mapper.Map<CreateCartResponse>(result);

            return CreatedAtAction(nameof(GetCartById), new { id = response.Id }, response);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCart([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteCartCommand(id);
            await _sender.Send(command, cancellationToken);

            // Retorna 204 No Content, que é a prática recomendada para uma operação DELETE bem-sucedida.
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResponse<CartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCarts([FromQuery] GetAllCartsRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetAllCartsQuery>(request);
            var result = await _sender.Send(query, cancellationToken);
            var response = _mapper.Map<PaginatedResponse<CartResponse>>(result);

            return Ok(response);
        }

        [HttpGet("{id:guid}", Name = "GetCartById")]
        [ProducesResponseType(typeof(GetCartByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCartById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetCartByIdQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            var response = _mapper.Map<GetCartByIdResponse>(result);

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(UpdateCartResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCart([FromRoute] Guid id, [FromBody] UpdateCartRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateCartCommand>(request);
            command.Id = id;

            var result = await _sender.Send(command, cancellationToken);
            var response = _mapper.Map<UpdateCartResponse>(result);

            return Ok(response);
        }
    }
}