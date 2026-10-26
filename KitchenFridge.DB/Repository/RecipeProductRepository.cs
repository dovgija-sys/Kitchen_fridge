using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitchenFridge.DB.Repository
{
    public class RecipeProductRepository : IRecipeProductRepository
    {
        private readonly KitchenFridgeContext _db;
        public RecipeProductRepository(KitchenFridgeContext db) => _db = db;
        public async Task<int> Add(RecipeProduct recipeProduct)
        {
            await _db.RecipeProducts.AddAsync(recipeProduct);
            await _db.SaveChangesAsync();
            return recipeProduct.Id;
        }
        public async Task<List<RecipeProduct>> Get()
        {
            return await _db.RecipeProducts.ToListAsync();
        }
        public async Task<RecipeProduct> GetRecipeProductById(int id)
        {
            return await _db.RecipeProducts.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task Update(RecipeProduct recipeProduct)
        {
            
            var updRecipeProduct = _db.RecipeProducts.FirstOrDefault(i => i.Id == recipeProduct.Id);
            if (updRecipeProduct != null)
            {
                updRecipeProduct = recipeProduct;
                _db.RecipeProducts.Update(updRecipeProduct);
                await _db.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var deleteRecipeProduct = await _db.RecipeProducts.FirstOrDefaultAsync(i => i.Id == id);
            if (deleteRecipeProduct != null)
            {
                _db.RecipeProducts.Remove(deleteRecipeProduct);
                await _db.SaveChangesAsync();
            }
        }
    }
}
