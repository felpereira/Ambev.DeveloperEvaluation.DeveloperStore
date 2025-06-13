using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts
{
    /// <summary>
    /// Requisição para buscar uma lista paginada de carrinhos.
    /// </summary>
    public class GetAllCartsRequest
    {
        /// <summary>
        /// O número da página a ser retornada. O padrão é 1.
        /// </summary>
        [FromQuery(Name = "page")]
        public int Page { get; set; } = 1;

        /// <summary>
        /// O número de itens por página. O padrão é 10.
        /// </summary>
        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = 10;
    }
}
