using ecommerco_proj.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerco_proj.DTOs.product
{
    public class ProductDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageProduct { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public decimal Qty { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

    }
}
