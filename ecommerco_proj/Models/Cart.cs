using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerco_proj.Models
{
    public class Cart
    {

        public int Id { get; set; }

        public string AppUserId { get; set; }
        public int ProductId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Qty { get; set; }

        public Product? Product { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
