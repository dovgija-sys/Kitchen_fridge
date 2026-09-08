using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;

namespace KitchenFridge.DB.Repository
{
    public class RecipeRepository: IRecipeRepository
    {
        private readonly KitchenFridgeContext _db;
        public RecipeRepository(KitchenFridgeContext db) => _db = db;
        public void Add(Recipe recipe)
        {
            _db.Recipes.Add(recipe);
            _db.SaveChanges();
        }
        public List<Recipe> Get()
        {
            var recipes = _db.Recipes.ToList();
            return recipes;
        }
        public void Update(int id, string newName)
        {
            var updRecipe = _db.Recipes.FirstOrDefault(n => n.Id == id);
            if (updRecipe != null)
            {
                updRecipe.Name = newName;
                _db.Recipes.Update(updRecipe);
                _db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            var deleteRecipe = _db.Recipes.FirstOrDefault(n => n.Id == id);
            if (deleteRecipe != null)
            {
                _db.Recipes.Remove(deleteRecipe);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
