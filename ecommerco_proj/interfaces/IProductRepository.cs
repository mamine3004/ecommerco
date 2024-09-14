using ecommerco_proj.DTOs.product;
using ecommerco_proj.Helpers;
using ecommerco_proj.Models;

namespace ecommerco_proj.interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(QueryObject query);
        Task<Product?> getByIdAsync(int id);
        Task<Product?> createAsync(Product productModel);
        Task<Product?> UpdateAsync(int id, UpdateProductDto updateProduct);
        Task<Product?> DeleteAsync(int id);
    }
}
