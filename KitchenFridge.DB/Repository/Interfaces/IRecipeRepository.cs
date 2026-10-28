using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        public Task<int> Add(Recipe recipe);
        public Task<List<Recipe>> Get();
        public Task Update(Recipe recipe);
        public Task Delete(int id);
        public Task<Recipe> GetRecipeById(int id);
    }
}
