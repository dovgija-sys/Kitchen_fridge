using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IFridgeRepository
    {
        public void Add(Fridge fridge);
        public List<Fridge> Get();
        public void Update(int id, string newName);
        public bool Delete(int id);
    }
}
