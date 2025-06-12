using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<Application.Common.DTOs.ProductRatingDto, Application.Products.ProductRatingDto>();

        CreateMap<Application.Products.ProductRatingDto, Application.Common.DTOs.ProductRatingDto>();


        CreateMap<CreateProductRequest, CreateProductCommand>();

        CreateMap<CreateProductResult, CreateProductResponse>();
    }
}
