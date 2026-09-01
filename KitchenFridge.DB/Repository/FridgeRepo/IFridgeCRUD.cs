using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.FridgeRepo
{
    public interface IFridgeCRUD
    {
        public void Add(Fridge fridge);
        public List<Fridge> Get();
        public void Update(int id, string newName);
        public bool Delete(int id);
    }
}
