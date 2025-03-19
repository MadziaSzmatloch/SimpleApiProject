using MyNewApi.Application.DTO;
using MyNewApi.Application.Managements.AddProduct;
using Refit;

namespace MyNewApi.Test
{
    public interface IMyNewApi
    {
        [Get("/products")]
        Task<IEnumerable<ProductDto>> GetProducts();

        [Post("/products")]
        Task<ApiResponse<ProductDetailDto>> CreateProduct([Body] AddProductRequest request);

        [Get("/ProductHistory")]
        Task<IEnumerable<ProductHistoryDto>> GetProductsHistories();
    }
}
