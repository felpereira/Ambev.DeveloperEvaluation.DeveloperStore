using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;
using Ambev.DeveloperEvaluation.Application.Products.GetCategories;
using Ambev.DeveloperEvaluation.Application.Products.GetProductById;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductById;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class ProductApiMappingProfile : Profile
    {
        public ProductApiMappingProfile()
        {
            CreateMap<Ambev.DeveloperEvaluation.Application.Common.DTOs.ProductRatingDto, Ambev.DeveloperEvaluation.Application.Products.ProductRatingDto>().ReverseMap();
            CreateMap<CreateProductRequest, CreateProductCommand>();
            CreateMap<CreateProductResult, CreateProductResponse>();

            CreateMap<GetAllProductsRequest, GetAllProductsQuery>();
            CreateMap<GetAllProductsResult, GetAllProductsResponse>();

            CreateMap<DeleteProductRequest, DeleteProductCommand>();
            CreateMap<DeleteProductResult, DeleteProductResponse>();

            CreateMap<GetCategoriesResult, GetCategoriesResponse>();

            CreateMap<GetProductsByIdRequest, GetProductsByIdQuery>();
            CreateMap<GetProductsByIdResult, GetProductsByIdResponse>();

            CreateMap<UpdateProductRequest, UpdateProductCommand>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateProductResult, UpdateProductResponse>();

        }
    }
}
