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
        public IActionResult GetProducts()
        {
            var products = _productsService.GetProducts();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            var product = _productsService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Add([FromBody] CreateProductDTO createProductDTO)
        {
            var response = _productsService.Add(createProductDTO);
            return StatusCode(StatusCodes.Status201Created, response);
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateProductDTO updateProductDTO)
        {
            _productsService.Update(updateProductDTO);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _productsService.Delete(id);
            return Ok();
        }
    }
}
