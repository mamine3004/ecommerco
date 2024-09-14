using ecommerco_proj.DTOs.Cart;
using ecommerco_proj.Models;

namespace ecommerco_proj.interfaces
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllAsync();
        Task<List<Cart>> GetByIdUser(string id);
        Task<Cart?> getByIdAsync(int id);
        Task<Cart?> CreateAsync(Cart cartModel);
        Task<Cart?> UpdateAsync(int id, UpdateCartDto updateCart);
        Task<Cart?> DeleteAsync(int id);

    }
}
