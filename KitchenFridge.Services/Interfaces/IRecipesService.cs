using KitchenFridge.DB.Entities;
using KitchenFridge.Services.DTOs;

namespace KitchenFridge.Services.Interfaces
{
    public interface IRecipesService
    {
        int Add(CreateRecipeDTO createRecipeDTO);
        void Delete(int id);
        List<Recipe> Get();
        Recipe GetRecipeById(int id);
        void Update(UpdateRecipeDTO updateRecipeDTO);
    }
}