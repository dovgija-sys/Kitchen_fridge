using KitchenFridge.DB.Entities.ProductEntities;
using KitchenFridge.Services.DTOs;
using KitchenFridge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KitchenFridge.WebApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FridgesController : ControllerBase
    {
        private readonly IFridgesService _fridgesService;
        public FridgesController(IFridgesService fridgesService) => _fridgesService = fridgesService;

        [HttpGet]
        public IActionResult GetFridges()
        {
            var fridges = _fridgesService.Get();
            if (fridges == null)
            {
                return NotFound();
            }
            return Ok(fridges);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetFridgeById([FromRoute] int id)
        {
            var fridge = _fridgesService.GetFridgeById(id);
            if (fridge == null)
            {
                return NotFound();
            }
            return Ok(fridge);
        }

        [HttpPost]
        public IActionResult AddFridge([FromBody] CreateFridgeDTO createFridgeDTO) {
            int response = _fridgesService.Add(createFridgeDTO);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        public IActionResult UpdateFridge([FromBody] UpdateFridgeDTO updateFridgeDTO)
        {
            _fridgesService.Update(updateFridgeDTO);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteFridge([FromRoute] int id)
        {
            _fridgesService.Delete(id);
            return Ok();
        }
    }
}
