using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitchenFridge.DB.Repository
{
    public class RecipeRepository: IRecipeRepository
    {
        private readonly KitchenFridgeContext _db;
        public RecipeRepository(KitchenFridgeContext db) => _db = db;
        public async Task<int> Add(Recipe recipe)
        {
            await _db.Recipes.AddAsync(recipe);
            await _db.SaveChangesAsync();
            return recipe.Id;
        }
        public async Task<List<Recipe>> Get()
        {
            return await _db.Recipes.ToListAsync();
        }
        public async Task<Recipe> GetRecipeById(int id)
        { 
            return await _db.Recipes.FirstOrDefaultAsync(r => r.Id == id);  
        }
        public async Task Update(Recipe recipe)
        {
            var updRecipe = _db.Recipes.FirstOrDefault(n => n.Id == recipe.Id);
            if (updRecipe != null)
            {
                updRecipe = recipe;
                _db.Recipes.Update(updRecipe);
                await _db.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var deleteRecipe = await _db.Recipes.FirstOrDefaultAsync(n => n.Id == id);
            if (deleteRecipe != null)
            {
                _db.Recipes.Remove(deleteRecipe);
                await _db.SaveChangesAsync();
            }
        }
    }
}
