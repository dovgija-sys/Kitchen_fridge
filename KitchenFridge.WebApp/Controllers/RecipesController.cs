using KitchenFridge.Services.DTOs;
using KitchenFridge.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace KitchenFridge.WebApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _recipesService;
        public RecipesController(IRecipesService recipesService) => _recipesService = recipesService;

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var fridges = await _recipesService.GetRcipes();
            if (fridges == null) 
            { 
                return NotFound(); 
            }
            return Ok(fridges);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecipeById([FromRoute]int id)
        {
            var recipe = await _recipesService.GetRecipeById(id);
            if(recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateRecipeDTO createRecipeDTO)
        {
            var response = await _recipesService.Add(createRecipeDTO);
            return StatusCode(StatusCodes.Status201Created,response);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRecipeDTO updateRecipeDTO)
        {
            await _recipesService.Update(updateRecipeDTO);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id) 
        {
            await _recipesService.Delete(id);
            return Ok();
        }
    }
}
