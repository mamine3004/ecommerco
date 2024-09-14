using ecommerco_proj.Models;

namespace ecommerco_proj.interfaces
{
    public interface ITokenService
    {
            string CreateToken(AppUser user);
    }
}
