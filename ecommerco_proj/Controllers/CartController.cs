using ecommerco_proj.DTOs.Cart;
using ecommerco_proj.DTOs.product;
using ecommerco_proj.interfaces;
using ecommerco_proj.Mappers;
using ecommerco_proj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ecommerco_proj.Controllers
{
    [Route("api/cart")]
    [ApiController]

    public class CartController : ControllerBase
    {
        private readonly CategoryContext _context;
        private readonly ICartRepository _cartRepo;
        private readonly UserManager<AppUser> _userManager;

        public CartController(CategoryContext context, ICartRepository cartRepo, UserManager<AppUser> userManager)
        {
            _context = context;
            _cartRepo = cartRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carts = await _cartRepo.GetAllAsync();
            var cartsDto = carts.Select(s => s.ToCartDto());
            return Ok(cartsDto);
        }

        //[HttpPost("{ProductId:int}/{userName:String}")]
        //public async Task<IActionResult> Create([FromRoute] int ProductId, CreateCartDtocs productDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    //            int categoryId = productModel.CategoryId;
        //    if (!await _cartRepo.CategoryExist(CategoryId))
        //    {
        //        return BadRequest("category id not exists");
        //    }
        //    var productModel = productDto.ToProductFromCreateDto(CategoryId);
        //    await _productRepo.createAsync(productModel);

        //    return CreatedAtAction(nameof(GetId), new { id = productModel.Id }, productModel.ToProductDto());

        //}


    }
}
