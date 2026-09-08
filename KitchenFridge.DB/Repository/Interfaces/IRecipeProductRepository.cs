using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IRecipeProductRepository
    {
        public void Add(RecipeProduct recipeProduct);
        public List<RecipeProduct> Get();
        public void Update(int id, RecipeProduct recipeProduct);
        public bool Delete(int id);
    }
}
