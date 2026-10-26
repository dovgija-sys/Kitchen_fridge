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
        public IActionResult GetRecipes()
        {
            var fridges = _recipesService.GetRcipes();
            if (fridges == null) 
            { 
                return NotFound(); 
            }
            return Ok(fridges);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetRecipeById([FromRoute]int id)
        {
            var recipe = _recipesService.GetRecipeById(id);
            if(recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }
        [HttpPost]
        public IActionResult Add([FromBody] CreateRecipeDTO createRecipeDTO)
        {
            var response = _recipesService.Add(createRecipeDTO);
            return StatusCode(StatusCodes.Status201Created,response);
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateRecipeDTO updateRecipeDTO)
        {
            _recipesService.Update(updateRecipeDTO);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute]int id) 
        {
            _recipesService.Delete(id);
            return Ok();
        }
    }
}
