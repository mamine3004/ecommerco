using ecommerco_proj.DTOs.Cart;
using ecommerco_proj.DTOs.product;
using ecommerco_proj.Models;
using Microsoft.CodeAnalysis;

namespace ecommerco_proj.Mappers
{
    public static class CartMappers
    {
        public static CartDto ToCartDto(this Cart cartModel)
        {
            return new CartDto
            {
                Qty = cartModel.Qty,
                Product = cartModel.Product.ToProductDto(),
            };
        }
        public static Cart ToCartFromCreateDto(this CreateCartDtocs createProductRequestDto, int ProductId, string AppUserId)
        {
            return new Cart
            {
                Qty = createProductRequestDto.Qty,
                ProductId = ProductId,
                AppUserId = AppUserId,
            };
        }
        public static Cart ToCartFromUpdateDto(this CreateCartDtocs createProductRequestDto)
        {
            return new Cart
            {
                Qty = createProductRequestDto.Qty,
            };
        }

    }
}
