using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IRecipeProductRepository
    {
        public int Add(RecipeProduct recipeProduct);
        public List<RecipeProduct> Get();
        public void Update(int id, RecipeProduct recipeProduct);
        public void Delete(int id);
    }
}
