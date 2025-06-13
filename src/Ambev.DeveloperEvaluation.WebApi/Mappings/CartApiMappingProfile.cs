using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;
using Ambev.DeveloperEvaluation.Application.Carts.GetCartById;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Application.Common.Models;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class CartApiMappingProfile : Profile
    {
        public CartApiMappingProfile()
        {
            CreateMap<CreateCartRequest, CreateCartCommand>();
            CreateMap<CartProductRequest, CreateCartItemDto>();

            CreateMap<GetAllCartsRequest, GetAllCartsQuery>();

            CreateMap<UpdateCartRequest, UpdateCartCommand>();
            CreateMap<CartItemUpdateRequest, UpdateCartItemDto>();

            CreateMap<CreateCartResult, CreateCartResponse>();
            CreateMap<Application.Carts.CreateCart.CartItemResultDto, WebApi.Features.Carts.CreateCart.CartProductResponse>();

            CreateMap<GetCartByIdResult, GetCartByIdResponse>();
            CreateMap<Application.Carts.GetCartById.CartItemResult, WebApi.Features.Carts.GetCartById.CartItemResponse>();

            CreateMap<Ambev.DeveloperEvaluation.Application.Common.Models.PaginatedList<GetAllCartsResult>, PaginatedResponse<CartResponse>>();
            CreateMap<GetAllCartsResult, CartResponse>();

            CreateMap<UpdateCartResult, UpdateCartResponse>();
            CreateMap<Application.Carts.UpdateCart.CartItemResult, WebApi.Features.Carts.UpdateCart.CartItemUpdateResponse>();

            // Regra para mapear a entidade Cart para o resultado UpdateCartResult
            CreateMap<Cart, UpdateCartResult>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)); // Mapeia a lista de itens

            // Regra para mapear a entidade CartItem para o DTO de item no resultado
            CreateMap<CartItem, Application.Carts.GetCartById.CartItemResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.)) // Mapeia o nome do produto
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.Price)); // Mapeia o preço do produto

        }
    }
}
