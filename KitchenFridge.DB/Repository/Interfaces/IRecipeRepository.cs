using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        public int Add(Recipe recipe);
        public List<Recipe> Get();
        public void Update(Recipe recipe);
        public void Delete(int id);
        Recipe GetRecipeById(int id);
    }
}
