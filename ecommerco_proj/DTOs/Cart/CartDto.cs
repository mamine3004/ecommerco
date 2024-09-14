using ecommerco_proj.DTOs.product;
using ecommerco_proj.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerco_proj.DTOs.Cart
{
    public class CartDto
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }
        public int ProductId { get; set; }

        public decimal Qty { get; set; }

        public Product? Product { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
