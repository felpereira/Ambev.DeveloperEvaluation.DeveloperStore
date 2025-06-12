using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductById;

/// <summary>
/// Perfil de mapeamento do AutoMapper para o fluxo de busca de produto por Id.
/// </summary>
public class GetProductsByIdProfile : Profile
{
    public GetProductsByIdProfile()
    {
        // Mapeia a entidade Product para o DTO de resultado GetProductsByIdResult.
        CreateMap<Product, GetProductsByIdResult>()
            // Mapeamento explícito para o DTO de avaliação, que possui tipo diferente.
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src =>
                new ProductRatingDto(src.ProductRating.Count, src.ProductRating.Rating)));
    }
}