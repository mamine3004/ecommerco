using ecommerco_proj.DTOs.category;
using ecommerco_proj.Models;

namespace ecommerco_proj.interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> CreateAsync(Category categoryModel);
        Task<Category?> UpdateAsync(int id,UpdateCategoryDto updateCategory);
        Task<Category?> DeleteAsync(int id);
        Task<bool> CategoryExist(int id);
    }
}
