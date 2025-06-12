using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    /// <summary>
    /// Define os mapeamentos do AutoMapper entre os DTOs da camada de Aplicação e da camada de API para a feature de Carrinho.
    /// </summary>
    public class CartApiMappingProfile : Profile
    {
        public CartApiMappingProfile()
        {
            // Mapeamento para a funcionalidade de Atualização de Carrinho
            CreateMap<UpdateCartResult, UpdateCartResponse>();
            CreateMap<CartItemResult, CartItemUpdateResponse>();
        }
    }
}
