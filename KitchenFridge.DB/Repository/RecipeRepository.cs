using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;

namespace KitchenFridge.DB.Repository
{
    public class RecipeRepository: IRecipeRepository
    {
        private readonly KitchenFridgeContext _db;
        public RecipeRepository(KitchenFridgeContext db) => _db = db;
        public int Add(Recipe recipe)
        {
            _db.Recipes.Add(recipe);
            _db.SaveChanges();
            return recipe.Id;
        }
        public List<Recipe> Get()
        {
            var recipes = _db.Recipes.ToList();
            return recipes;
        }
        public Recipe GetRecipeById(int id)
        {
            var recipe = _db.Recipes.FirstOrDefault(r => r.Id == id);
            return recipe; 
        }
        public void Update(Recipe recipe)
        {
            var updRecipe = _db.Recipes.FirstOrDefault(n => n.Id == recipe.Id);
            if (updRecipe != null)
            {
                updRecipe.Name = recipe.Name;
                _db.Recipes.Update(updRecipe);
                _db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var deleteRecipe = _db.Recipes.FirstOrDefault(n => n.Id == id);
            if (deleteRecipe != null)
            {
                _db.Recipes.Remove(deleteRecipe);
                _db.SaveChanges();
            }
        }
    }
}
