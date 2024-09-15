using ecommerco_proj.DTOs.Cart;
using ecommerco_proj.Models;

namespace ecommerco_proj.Mappers
{
    public static class CartMappers
    {
        public static CartDto ToCartDto(this Cart cartModel)
        {
            return new CartDto
            {
                Id = cartModel.Id,
                Qty = cartModel.Qty,
                Product = cartModel.Product,
//                AppUserId = cartModel.AppUserId,
 //               AppUser = cartModel.AppUser,
                ProductId = cartModel.ProductId,
            };
        }
        public static Cart ToCartFromCreateDto(this CreateCartDtocs createCartRequestDto, int ProductId, string AppUserId)
        {

            return new Cart
            {
                Qty = createCartRequestDto.Qty,
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
