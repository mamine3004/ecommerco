
using ecommerco_proj.DTOs.category;
using ecommerco_proj.Models;

namespace ecommerco_proj.Mappers
{
    public static class CategoryMappers
    {

        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description,
//                Products = categoryModel.Products.Select(p => p.ToProductDto()).ToList(),
            };
        }
        public static Category ToCategoryFromCreateDto(this CreateCategoryRequestDto createCategoryRequestDto)
        {
            return new Category{
                Name = createCategoryRequestDto.Name,
                Description = createCategoryRequestDto.Description
            };
        }
    }
}
