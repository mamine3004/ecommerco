using ecommerco_proj.DTOs.product;
using ecommerco_proj.Models;

namespace ecommerco_proj.DTOs.category
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<ProductDto?> Products { get; set; }
    }
}
