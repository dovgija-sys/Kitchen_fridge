using KitchenFridge.Services.Interfaces;
using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;
using KitchenFridge.Services.DTOs;

namespace KitchenFridge.Services.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipesService(IRecipeRepository fridgeRepository)
        {
            _recipeRepository = fridgeRepository;
        }

        public List<Recipe> Get()
        {
            return _recipeRepository.Get();
        }
        public Recipe GetRecipeById(int id)
        {
            return _recipeRepository.GetRecipeById(id);
        }

        public int Add(CreateRecipeDTO createRecipeDTO)
        {
            return _recipeRepository.Add(new Recipe { Name = createRecipeDTO.Name });
        }

        public void Update(UpdateRecipeDTO updateRecipeDTO)
        {

            _recipeRepository.Update(new Recipe
            {
                Id = updateRecipeDTO.Id,
                Name = updateRecipeDTO.Name
            });
        }
        public void Delete(int id)
        {
            _recipeRepository.Delete(id);
        }
    }
}
