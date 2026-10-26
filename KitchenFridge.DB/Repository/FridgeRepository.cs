using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitchenFridge.DB.Repository
{
    public class FridgeRepository : IFridgeRepository
    {
        private readonly KitchenFridgeContext _db;
        public FridgeRepository(KitchenFridgeContext db) => _db = db;
        public async Task<int> Add(Fridge fridge)
        {
            await _db.Fridges.AddAsync(fridge);
            await _db.SaveChangesAsync();

            return fridge.Id;
        }
        public async Task<List<Fridge>> Get()
        {
            return await _db.Fridges.ToListAsync();
        }

        public async Task<Fridge> GetFridgeById(int id)
        {
            return await _db.Fridges.FirstOrDefaultAsync(n => n.Id == id);
        }
        public async Task Update(Fridge fridge)
        {
            var updFridge = await _db.Fridges.FirstOrDefaultAsync(n => n.Id == fridge.Id);
            if (updFridge != null)
            {
                updFridge.Name = fridge.Name;
                _db.Fridges.Update(updFridge);
                await _db.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var deleteFridge = await _db.Fridges.FirstOrDefaultAsync(n => n.Id == id);
            if (deleteFridge != null)
            {
                _db.Fridges.Remove(deleteFridge);
                await _db.SaveChangesAsync();
            }
        }
    }
}
