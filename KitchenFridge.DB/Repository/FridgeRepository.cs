using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;

namespace KitchenFridge.DB.Repository
{
    public class FridgeRepository : IFridgeRepository
    {
        private readonly KitchenFridgeContext _db;
        public FridgeRepository(KitchenFridgeContext db) => _db = db;
        public void Add(Fridge fridge)
        {
            
            _db.Fridges.Add(fridge);
            _db.SaveChanges();
        }
        public List<Fridge> Get()
        {
            var fridges = _db.Fridges.ToList();
            return fridges;
        }
        public void Update(int id, string newName)
        {
            var updFridge = _db.Fridges.FirstOrDefault(n => n.Id == id);
            if (updFridge != null)
            {
                updFridge.Name = newName;
                _db.Fridges.Update(updFridge);
                _db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            var deleteFridge = _db.Fridges.FirstOrDefault(n => n.Id == id);
            if (deleteFridge != null)
            {
                _db.Fridges.Remove(deleteFridge);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
