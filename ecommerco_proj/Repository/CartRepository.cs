using ecommerco_proj.DTOs.Cart;
using ecommerco_proj.DTOs.category;
using ecommerco_proj.interfaces;
using ecommerco_proj.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ecommerco_proj.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly CategoryContext _context;
        public CartRepository(CategoryContext context)
        {
            _context = context;
        }

        public async Task<Cart?> CreateAsync(Cart cartModel)
        {
            await _context.carts.AddAsync(cartModel); ;
            await _context.SaveChangesAsync();
            return cartModel;

        }

        public async Task<Cart?> DeleteAsync(int id)
        {
            var cartModel = await _context.carts.FirstOrDefaultAsync(x => x.Id == id);
            if (cartModel == null)
            {
                return null;
            }
            _context.carts.Remove(cartModel);

            await _context.SaveChangesAsync();

            return cartModel;
        }

        public Task<List<Cart>> GetAllAsync()
        {
            return _context.carts.Include(p => p.Product).ToListAsync();
            //return _context.carts.ToListAsync();
        }

        public Task<Cart?> getByIdAsync(int id)
        {
            return _context.carts.Include(p => p.Product).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<List<Cart>> GetByIdUser(string id)
        {
            var carts = _context.carts.AsQueryable();
            carts = carts.Where(p => p.AppUserId == id);
            return carts.Include(p => p.Product).ToListAsync();
        }

        public async Task<Cart?> UpdateAsync(int id, UpdateCartDto updateCart)
        {
            var categoryModel = await _context.carts.Include(p => p.Product).FirstOrDefaultAsync(x => x.Id == id);
            if (categoryModel == null)
            {
                return null;
            }
            categoryModel.Qty = updateCart.Qty;

            await _context.SaveChangesAsync();
            return categoryModel;
        }
    }
}
