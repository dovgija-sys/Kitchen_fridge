using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.RecipeProductRepo
{
    public class RecipeProductCRUD : IRecipeProductCRUD
    {
        public void Add(RecipeProduct recipeProduct)
        {
            using var db = new KitchenFridgeContext();
            db.RecipeProducts.Add(recipeProduct);
            db.SaveChanges();
        }
        public List<RecipeProduct> Get()
        {
            using var db = new KitchenFridgeContext();
            var recipeProducts = db.RecipeProducts.ToList();
            return recipeProducts;
        }
        public void Update(int id, RecipeProduct recipeProduct)
        {
            using var db = new KitchenFridgeContext();
            var updRecipeProduct = db.RecipeProducts.FirstOrDefault(i => i.Id == id);
            if (updRecipeProduct != null)
            {
                updRecipeProduct = recipeProduct;
                db.RecipeProducts.Update(updRecipeProduct);
                db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            using var db = new KitchenFridgeContext();
            var deleteRecipeProduct = db.RecipeProducts.FirstOrDefault(i => i.Id == id);
            if (deleteRecipeProduct != null)
            {
                db.RecipeProducts.Remove(deleteRecipeProduct);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
