using ecommerco_proj.DTOs.product;
using ecommerco_proj.Models;

namespace ecommerco_proj.Mappers
{
    public static class ProductMappers
    {

        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                CreatedDate = productModel.CreatedDate,
                Price = productModel.Price,
                Qty = productModel.Qty,
                CategoryId = productModel.CategoryId,
                ImageProduct = productModel.ImageProduct
            };
        }
        public static Product ToProductFromCreateDto(this CreateProductRequestDto createProductRequestDto,int CategoryId)
        {
            return new Product
            {
                Name = createProductRequestDto.Name,
                Description = createProductRequestDto.Description,
                ImageProduct =  createProductRequestDto.ImageProduct,
                Price = createProductRequestDto.Price,
                Qty = createProductRequestDto.Qty,
                CategoryId = CategoryId,
            };
        }
        public static Product ToProductFromUpdateDto(this CreateProductRequestDto createProductRequestDto)
        {
            return new Product
            {
                Name = createProductRequestDto.Name,
                Description = createProductRequestDto.Description,
                ImageProduct =  createProductRequestDto.ImageProduct,
                Price = createProductRequestDto.Price,
                Qty = createProductRequestDto.Qty,
            };
        }


    }
}
