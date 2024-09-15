using ecommerco_proj.DTOs.Cart;
using ecommerco_proj.DTOs.product;
using ecommerco_proj.interfaces;
using ecommerco_proj.Mappers;
using ecommerco_proj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing.Printing;

namespace ecommerco_proj.Controllers
{
    [Route("api/cart")]
    [ApiController]

    public class CartController : ControllerBase
    {
        private readonly CategoryContext _context;
        private readonly ICartRepository _cartRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductRepository _productRepo;

        public CartController(CategoryContext context, ICartRepository cartRepo, UserManager<AppUser> userManager, IProductRepository productRepo)
        {
            _context = context;
            _cartRepo = cartRepo;
            _userManager = userManager;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carts = await _cartRepo.GetAllAsync();
            var cartsDto = carts.Select(s => s.ToCartDto());
            return Ok(cartsDto);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUsername([FromRoute] string username)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username.ToLower());

            if (user == null) return BadRequest("Invalid username!");

            var carts = await _cartRepo.GetByIdUser(user.Id);
            var cartsDto = carts.Select(s => s.ToCartDto());
            return Ok(cartsDto);
        }


        [HttpPost("{ProductId:int}/{userName}")]

        public async Task<IActionResult> Create([FromRoute] int ProductId, [FromRoute] string userName, CreateCartDtocs cartDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //            int categoryId = productModel.CategoryId;
            if (!await _productRepo.ProductExist(ProductId))
            {
                return BadRequest("category id not exists");
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName.ToLower());

            if (user == null) return BadRequest("Invalid username!");

            var cartModel = cartDto.ToCartFromCreateDto(ProductId,user.Id);
            await _cartRepo.CreateAsync(cartModel);

            return CreatedAtAction(nameof(GetId), new { id = cartModel.Id }, cartModel.ToCartDto());

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            var cart = await _cartRepo.getByIdAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart.ToCartDto());
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCartDto updateCart)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cartModel = await _cartRepo.UpdateAsync(id, updateCart);
            if (cartModel == null)
            {
                return NotFound("product not exists");
            }

            return Ok(cartModel.ToCartDto());

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var cartModel = await _cartRepo.DeleteAsync(id);
            if (cartModel == null)
            {
                return NotFound("product not exists");
            }

            return Ok(cartModel.ToCartDto());

        }


    }
}
