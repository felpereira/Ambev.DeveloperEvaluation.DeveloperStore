namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts
{
    public class GetAllCartsResult
    {
        public List<CartDto> Data { get; set; } = new();
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
