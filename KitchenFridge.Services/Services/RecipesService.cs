using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository;
using KitchenFridge.DB.Repository.Interfaces;
using KitchenFridge.Services.DTOs;
using KitchenFridge.Services.Exceptions;
using KitchenFridge.Services.Interfaces;

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
            if (string.IsNullOrEmpty(createRecipeDTO.Name))
            {
                throw new ValidationException("Recipe name can't be null or empty");
            }
            else if (createRecipeDTO.Name.Length > 20)
            {
                throw new ValidationException("recipe name lenth is to be less than 20");
            }
            else if (createRecipeDTO.Name.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ValidationException("Recipe name can't contain specials");
            }
            return _recipeRepository.Add(new Recipe { Name = createRecipeDTO.Name });
        }

        public void Update(UpdateRecipeDTO updateRecipeDTO)
        {
            if (updateRecipeDTO.Id <= 0)
            {
                throw new ValidationException("Id can't be less than or equal to 0");
            }
            else if (string.IsNullOrEmpty(updateRecipeDTO.Name))
            {
                throw new ValidationException("Recipe name can't be null or empty");
            }
            else if (updateRecipeDTO.Name.Length > 20)
            {
                throw new ValidationException("Recipe name lenth is to be less than 20");
            }
            else if (updateRecipeDTO.Name.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ValidationException("Recipe name can't contain specials");
            }
            var updateRecipe = _recipeRepository.GetRecipeById(updateRecipeDTO.Id);
            updateRecipe.Name = updateRecipeDTO.Name;
            updateRecipe.Id = updateRecipeDTO.Id;
            _recipeRepository.Update(updateRecipe);
        }
        public void Delete(int id)
        {
            _recipeRepository.Delete(id);
        }
    }
}
