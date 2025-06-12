using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Define os perfis de mapeamento do AutoMapper para o fluxo de criação de produto na camada da API.
/// </summary>
public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        // Mapeamento para o DTO aninhado (Request -> Command)
        // Converte o DTO da camada da API para o DTO da camada de Aplicação.
        CreateMap<Application.Common.DTOs.ProductRatingDto, Application.Products.ProductRatingDto>();

        // Mapeamento para o DTO aninhado (Result -> Response) - ADICIONADO PARA CORRIGIR O ERRO
        // Converte o DTO da camada de Aplicação de volta para o DTO da camada da API.
        CreateMap<Application.Products.ProductRatingDto, Application.Common.DTOs.ProductRatingDto>();


        // Passo 1: Mapear a Requisição da API (Request) para o Comando da Aplicação (Command).
        // Este mapeamento agora funcionará, pois o AutoMapper sabe como resolver a propriedade aninhada 'Rating'.
        CreateMap<CreateProductRequest, CreateProductCommand>();

        // Passo 2: Mapear o Resultado da Aplicação (Result) para a Resposta da API (Response).
        // Este mapeamento agora funcionará com a adição da regra de mapeamento reverso para o Rating.
        CreateMap<CreateProductResult, CreateProductResponse>();
    }
}
