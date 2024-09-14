using System.ComponentModel.DataAnnotations;

namespace ecommerco_proj.DTOs.Cart
{
    public class CreateCartDtocs
    {
        [Required]
        [Range(0.5, 10000000)]

        public decimal Qty { get; set; }

    }
}
