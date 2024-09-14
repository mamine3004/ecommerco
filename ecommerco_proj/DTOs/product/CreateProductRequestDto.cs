using ecommerco_proj.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerco_proj.DTOs.product
{
    public class CreateProductRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageProduct { get; set; } = string.Empty;
        [Required]
        [Range(0.5, 10000000)]
        public decimal Price { get; set; }
        public decimal Qty { get; set; }



    }
}
