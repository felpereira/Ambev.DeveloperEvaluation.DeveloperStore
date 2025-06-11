
using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;


public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {

        CreateMap<CreateProductCommand, Product>()
            .ConstructUsing(src => Product.Create(
                src.Price,
                src.Title,
                src.Description,
                src.Category,
                src.Image,
                new ProductRating(src.Rating.Count, src.Rating.Rating)
            ));

        CreateMap<Product, CreateProductResult>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src =>
                new ProductRatingDto(src.ProductRating.Count, src.ProductRating.Rating)));

        CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src =>
                    new ProductRatingDto(src.ProductRating.Count, src.ProductRating.Rating)));
    }
}