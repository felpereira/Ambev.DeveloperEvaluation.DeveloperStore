using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;
using Ambev.DeveloperEvaluation.Application.Carts.GetCartById;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;
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
        


            // Create Cart
            CreateMap<CreateCartRequest, CreateCartCommand>();
            CreateMap<CreateCartResult, CreateCartResponse>();

            // Get All Carts
            CreateMap<GetAllCartsRequest, GetAllCartsQuery>();
            //CreateMap<GetAllCartsResult, GetAllCartsResponse>();

            // Get Cart By Id
            CreateMap<GetCartByIdRequest, GetCartByIdQuery>();
            //CreateMap<GetCartByIdResult, GetCartByIdResponse>();

            // Update Cart
            CreateMap<UpdateCartRequest, UpdateCartCommand>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // O Id virá da rota
            //CreateMap<UpdateCartResult, UpdateCartResponse>();

            // Delete Cart
            CreateMap<DeleteCartRequest, DeleteCartCommand>();
        }
    }
}