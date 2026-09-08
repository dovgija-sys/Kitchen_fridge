using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;

namespace KitchenFridge.DB.Repository
{
    public class RecipeProductRepository : IRecipeProductRepository
    {
        private readonly KitchenFridgeContext _db;
        public RecipeProductRepository(KitchenFridgeContext db) => _db = db;
        public void Add(RecipeProduct recipeProduct)
        {
            _db.RecipeProducts.Add(recipeProduct);
            _db.SaveChanges();
        }
        public List<RecipeProduct> Get()
        {
            var recipeProducts = _db.RecipeProducts.ToList();
            return recipeProducts;
        }
        public void Update(int id, RecipeProduct recipeProduct)
        {
            
            var updRecipeProduct = _db.RecipeProducts.FirstOrDefault(i => i.Id == id);
            if (updRecipeProduct != null)
            {
                updRecipeProduct = recipeProduct;
                _db.RecipeProducts.Update(updRecipeProduct);
                _db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            var deleteRecipeProduct = _db.RecipeProducts.FirstOrDefault(i => i.Id == id);
            if (deleteRecipeProduct != null)
            {
                _db.RecipeProducts.Remove(deleteRecipeProduct);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
