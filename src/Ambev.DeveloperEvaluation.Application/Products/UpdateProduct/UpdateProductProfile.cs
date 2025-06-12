// Ambev.DeveloperEvaluation.Application.Products.UpdateProduct/UpdateProductProfile.cs
using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        // Mapeia do Comando para a Entidade para ATUALIZAR uma instância existente.
        // O AutoMapper irá copiar os valores das propriedades do comando para a entidade.
        CreateMap<UpdateProductCommand, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o Id para não sobrescrever a chave primária
            .ForMember(dest => dest.ProductRating, opt => opt.MapFrom(src =>
                new ProductRating(src.Rating.Count, src.Rating.Rating))); // Mapeia o DTO para o Value Object

        // Mapeia da Entidade para o Resultado
        CreateMap<Product, UpdateProductResult>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src =>
                new ProductRatingDto(src.ProductRating.Count, src.ProductRating.Rating)));
    }
}