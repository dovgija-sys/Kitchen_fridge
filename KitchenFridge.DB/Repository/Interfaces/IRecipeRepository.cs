using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        public void Add(Recipe recipe);
        public List<Recipe> Get();
        public void Update(int id, string newName);
        public bool Delete(int id);
    }
}
