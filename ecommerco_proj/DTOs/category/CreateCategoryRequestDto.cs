using System.ComponentModel.DataAnnotations;

namespace ecommerco_proj.DTOs.category
{
    public  class CreateCategoryRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
