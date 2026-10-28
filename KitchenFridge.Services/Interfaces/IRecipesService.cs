using KitchenFridge.DB.Entities;
using KitchenFridge.Services.DTOs;

namespace KitchenFridge.Services.Interfaces
{
    public interface IRecipesService
    {
        public Task<int> Add(CreateRecipeDTO createRecipeDTO);
        public Task Delete(int id);
        public Task<List<Recipe>> GetRcipes();
        public Task<Recipe> GetRecipeById(int id);
        public Task Update(UpdateRecipeDTO updateRecipeDTO);
    }
}