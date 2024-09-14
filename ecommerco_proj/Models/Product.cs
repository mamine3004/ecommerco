using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerco_proj.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageProduct { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Qty { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

//        public List<Cart?> Carts { get; set; } = new List<Cart>();

    }
}
