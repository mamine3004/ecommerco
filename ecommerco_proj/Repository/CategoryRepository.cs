using ecommerco_proj.DTOs.category;
using ecommerco_proj.interfaces;
using ecommerco_proj.Mappers;
using ecommerco_proj.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace ecommerco_proj.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryContext _context;
        public CategoryRepository(CategoryContext context)
        {
            _context = context;
        }

        public Task<bool> CategoryExist(int id)
        {
            return _context.categories.AnyAsync(i => i.Id == id);
        }

        public async Task<Category?> CreateAsync(Category categoryModel)
        {
            await _context.categories.AddAsync(categoryModel); ;
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var categoryModel = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categoryModel == null)
            {
                return null;
            }
            _context.categories.Remove(categoryModel);

            await _context.SaveChangesAsync();

            return categoryModel;
        }

        public Task<List<Category>> GetAllAsync()
        {
            return _context.categories.Include(p=>p.Products).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.categories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Category?> UpdateAsync(int id, UpdateCategoryDto updateCategory)
        {
            var categoryModel = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categoryModel == null)
            {
                return null;
            }
            categoryModel.Name = updateCategory.Name;
            categoryModel.Description = updateCategory.Description;

            await _context.SaveChangesAsync();
            return categoryModel;
        }
    }
}
