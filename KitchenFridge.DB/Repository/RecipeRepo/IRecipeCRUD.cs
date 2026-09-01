using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.RecipeRepo
{
    public interface IRecipeCRUD
    {
        public void Add(Recipe recipe);
        public List<Recipe> Get();
        public void Update(int id, string newName);
        public bool Delete(int id);
    }
}
