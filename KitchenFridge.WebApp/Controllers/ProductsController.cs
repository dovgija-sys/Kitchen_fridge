using KitchenFridge.DB.Entities.ProductEntities;
using KitchenFridge.Services.DTOs;
using KitchenFridge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace KitchenFridge.WebApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService) => _productsService = productsService;

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productsService.GetProducts();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productsService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductDTO createProductDTO)
        {
            var response = await _productsService.Add(createProductDTO);
            return StatusCode(StatusCodes.Status201Created, response);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDTO updateProductDTO)
        {
            await _productsService.Update(updateProductDTO);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _productsService.Delete(id);
            return Ok();
        }
    }
}
