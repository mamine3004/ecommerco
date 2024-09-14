using Microsoft.AspNetCore.Identity;

namespace ecommerco_proj.Models
{
    public class AppUser:IdentityUser
    {
        public List<Cart?> Carts { get; set; } = new List<Cart>();

    }
}
