using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.FridgeRepo
{
    public class FridgeCRUD : IFridgeCRUD
    {
        public void Add(Fridge fridge)
        {
            using var db = new KitchenFridgeContext();
            db.Fridges.Add(fridge);
            db.SaveChanges();
        }
        public List<Fridge> Get()
        {
            using var db = new KitchenFridgeContext();
            var fridges = db.Fridges.ToList();
            return fridges;
        }
        public void Update(int id, string newName)
        {
            using var db = new KitchenFridgeContext();
            var updFridge = db.Fridges.FirstOrDefault(n => n.Id == id);
            if (updFridge != null)
            {
                updFridge.Name = newName;
                db.Fridges.Update(updFridge);
                db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            using var db = new KitchenFridgeContext();
            var deleteFridge = db.Fridges.FirstOrDefault(n => n.Id == id);
            if (deleteFridge != null)
            {
                db.Fridges.Remove(deleteFridge);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
