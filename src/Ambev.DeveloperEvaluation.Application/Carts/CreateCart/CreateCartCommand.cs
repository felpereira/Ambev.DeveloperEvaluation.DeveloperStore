
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public record CreateCartCommand(
    Guid UserId,
    List<CartItemCommand> Products) : IRequest<CreateCartResult>;

public record CartItemCommand(
    Guid ProductId,
    int Quantity);