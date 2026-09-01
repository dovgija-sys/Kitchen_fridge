using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.RecipeProductRepo
{
    public interface IRecipeProductCRUD
    {
        public void Add(RecipeProduct recipeProduct);
        public List<RecipeProduct> Get();
        public void Update(int id, RecipeProduct recipeProduct);
        public bool Delete(int id);
    }
}
