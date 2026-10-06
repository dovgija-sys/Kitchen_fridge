using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;

namespace KitchenFridge.DB.Repository
{
    public class FridgeRepository : IFridgeRepository
    {
        private readonly KitchenFridgeContext _db;
        public FridgeRepository(KitchenFridgeContext db) => _db = db;
        public int Add(Fridge fridge)
        {
            _db.Fridges.Add(fridge);
            _db.SaveChanges();

            return fridge.Id;
        }
        public List<Fridge> Get()
        {
            var fridges = _db.Fridges.ToList();
            return fridges;
        }

        public Fridge GetFridgeById(int id)
        {
            var fridge = _db.Fridges.FirstOrDefault(n => n.Id == id);
            if (fridge == null)
            {
                return null;
            }
            return fridge;
        }
        public void Update(Fridge fridge)
        {
            var updFridge = _db.Fridges.FirstOrDefault(n => n.Id == fridge.Id);
            if (updFridge != null)
            {
                updFridge.Name = fridge.Name;
                _db.Fridges.Update(updFridge);
                _db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var deleteFridge = _db.Fridges.FirstOrDefault(n => n.Id == id);
            if (deleteFridge != null)
            {
                _db.Fridges.Remove(deleteFridge);
                _db.SaveChanges();
            }
        }
    }
}
