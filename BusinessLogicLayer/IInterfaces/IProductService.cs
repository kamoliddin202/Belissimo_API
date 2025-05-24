using DTOs.ProductDtos;

namespace BusinessLogicLayer.IInterfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task AddProductAsync(AddProductDo addProductDo);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<ProductDto>> GetProductWithOrderItemsAsync();

    }
}
