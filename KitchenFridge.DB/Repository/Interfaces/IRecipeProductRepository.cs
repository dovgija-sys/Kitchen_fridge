using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IRecipeProductRepository
    {
        public Task<int> Add(RecipeProduct recipeProduct);
        public Task<List<RecipeProduct>> Get();
        public Task<RecipeProduct> GetRecipeProductById(int id);
        public Task Update(RecipeProduct recipeProduct);
        public Task Delete(int id);
    }
}
