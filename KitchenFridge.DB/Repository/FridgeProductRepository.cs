using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitchenFridge.DB.Repository
{
    public class FridgeProductRepository : IFridgeProductRepository
    {
        private readonly KitchenFridgeContext _db;
        public FridgeProductRepository(KitchenFridgeContext db) => _db = db;
        public async Task<int> Add(FridgeProduct fridgeProduct)
        {
            await _db.FridgeProducts.AddAsync(fridgeProduct);
            await _db.SaveChangesAsync();
            return fridgeProduct.Id;
        }
        public async Task<FridgeProduct> GetFridgeProductById(int id) {
            return await _db.FridgeProducts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<FridgeProduct>> Get()
        {
            return await _db.FridgeProducts.ToListAsync();
        }
        public async Task Update(FridgeProduct fridgeProduct)
        {
            var updFridgeProduct = _db.FridgeProducts.FirstOrDefault(i => i.Id == fridgeProduct.Id);
            if(updFridgeProduct != null)
            {
                updFridgeProduct = fridgeProduct;
                _db.FridgeProducts.Update(updFridgeProduct);
                await _db.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var deleteFridgeProduct = await _db.FridgeProducts.FirstOrDefaultAsync(i => i.Id == id);
            if (deleteFridgeProduct != null) 
            {
                _db.FridgeProducts.Remove(deleteFridgeProduct);
                await _db.SaveChangesAsync();
            }
        }
    }
}
