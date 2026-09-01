using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.RecipeRepo
{
    public class RecipeCRUD: IRecipeCRUD
    {
        public void Add(Recipe recipe)
        {
            using var db = new KitchenFridgeContext();
            db.Recipes.Add(recipe);
            db.SaveChanges();
        }
        public List<Recipe> Get()
        {
            using var db = new KitchenFridgeContext();
            var recipes = db.Recipes.ToList();
            return recipes;
        }
        public void Update(int id, string newName)
        {
            using var db = new KitchenFridgeContext();
            var updRecipe = db.Recipes.FirstOrDefault(n => n.Id == id);
            if (updRecipe != null)
            {
                updRecipe.Name = newName;
                db.Recipes.Update(updRecipe);
                db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            using var db = new KitchenFridgeContext();
            var deleteRecipe = db.Recipes.FirstOrDefault(n => n.Id == id);
            if (deleteRecipe != null)
            {
                db.Recipes.Remove(deleteRecipe);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
