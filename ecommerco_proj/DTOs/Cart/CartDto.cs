using ecommerco_proj.DTOs.product;

namespace ecommerco_proj.DTOs.Cart
{
    public class CartDto
    {
        public decimal Qty { get; set; }

        public ProductDto? Product { get; set; }

    }
}
