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
        public FridgesController(IFridgesService fridgesService)
        {
            _fridgesService = fridgesService;
        }
        [HttpGet]
        public async Task<IActionResult> GetFridges()
        {
            var fridges = await _fridgesService.GetFridges();
            if (fridges == null)
            {
                return NotFound();
            }
            return Ok(fridges);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFridgeById([FromRoute] int id)
        {
            var fridge = await _fridgesService.GetFridgeById(id);
            if (fridge == null)
            {
                return NotFound();
            }
            return Ok(fridge);
        }

        [HttpPost]
        public async Task<IActionResult> AddFridge([FromBody] CreateFridgeDTO createFridgeDTO) {
            int response = await _fridgesService.Add(createFridgeDTO);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFridge([FromBody] UpdateFridgeDTO updateFridgeDTO)
        {
            await _fridgesService.Update(updateFridgeDTO);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFridge([FromRoute] int id)
        {
            await _fridgesService.Delete(id);
            return Ok();
        }
    }
}
