using ecommerco_proj.DTOs.category;
using ecommerco_proj.DTOs.product;
using ecommerco_proj.Helpers;
using ecommerco_proj.interfaces;
using ecommerco_proj.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerco_proj.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       // private readonly CategoryContext _context;
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        public ProductController(CategoryContext context, IProductRepository productRepo, ICategoryRepository categoryRepo) {
  //          _context = context;
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var products = await _productRepo.GetAllAsync(query);
            var productDto = products.Select(s => s.ToProductDto());
            return Ok(productDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult >GetId([FromRoute] int id)
        {
            var product = await _productRepo.getByIdAsync(id);
            if (product == null) {
                return NotFound();
            }     

            return Ok(product.ToProductDto());
        }

        [HttpPost("{CategoryId:int}")]
        public async Task<IActionResult >Create([FromRoute] int CategoryId, CreateProductRequestDto productDto )
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
//            int categoryId = productModel.CategoryId;
            if (!await _categoryRepo.CategoryExist(CategoryId))
            {
                return BadRequest("category id not exists");
            }
            var productModel = productDto.ToProductFromCreateDto(CategoryId);
            await _productRepo.createAsync(productModel);

            return CreatedAtAction(nameof(GetId), new { id = productModel.Id }, productModel.ToProductDto());

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto updateProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productModel = await _productRepo.UpdateAsync(id,updateProduct);
            if (productModel == null)
            {
                return NotFound("product not exists");
            }

            return Ok(productModel.ToProductDto());

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var productModel = await _productRepo.DeleteAsync(id);
            if (productModel == null)
            {
                return NotFound("product not exists");
            }

            return Ok(productModel.ToProductDto());

        }


    }
}
