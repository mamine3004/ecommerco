using ecommerco_proj.DTOs.product;
using ecommerco_proj.Helpers;
using ecommerco_proj.interfaces;
using ecommerco_proj.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerco_proj.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CategoryContext _context;
        public ProductRepository(CategoryContext context)
        {
            _context = context;
        }

        public async Task<Product?> createAsync(Product productModel)
        {
            await _context.products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                return null;
            }
            _context.products.Remove(productModel);
            await _context.SaveChangesAsync();

            return productModel;
        }

        public async Task<List<Product>> GetAllAsync(QueryObject query)
        {
            var products  =  _context.products.AsQueryable();
            if (query.CategoryId > 0)
            {
                products = products.Where(p => p.CategoryId == query.CategoryId);
            }
            if (!string.IsNullOrWhiteSpace(query.name))
            {
                products =  products.Where(p=> p.Name.Contains(query.name) || p.Description.Contains(query.name));
            }
            if (query.price>0)
            {
                products = products.Where(p=> p.Price >= query.price);
            }
            if (query.qty>0)
            {
                products = products.Where(p=> p.Qty >= query.qty);
            }
            if(!string.IsNullOrWhiteSpace(query.sortBy))
            {
                if (query.sortBy.Equals("CreatedDate",StringComparison.OrdinalIgnoreCase)){
                    products = query.isDecsending ? products.OrderByDescending(s=>s.CreatedDate) :products.OrderBy(s=>s.CreatedDate);
                }else if (query.sortBy.Equals("price", StringComparison.OrdinalIgnoreCase)) {
                    products = query.isDecsending ? products.OrderByDescending(s => s.Price) : products.OrderBy(s => s.Price);
                }
            }

            var skipNumber = (query.PageNumber-1) * query.PageSize;

            return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public Task<Product?> getByIdAsync(int id)
        {
            return _context.products.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Product?> UpdateAsync(int id, UpdateProductDto updateProduct)
        {
            var productModel = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                return null;
            }
            productModel.Name = updateProduct.Name;
            productModel.Description = updateProduct.Description;
            productModel.Price = updateProduct.Price;
            productModel.Qty = updateProduct.Qty;
            productModel.ImageProduct = updateProduct.ImageProduct;

            await _context.SaveChangesAsync();

            return productModel;
        }
    }
}
