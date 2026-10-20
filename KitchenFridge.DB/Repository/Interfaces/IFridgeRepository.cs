using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IFridgeRepository
    {
        public int Add(Fridge fridge);
        public List<Fridge> Get();
        public void Delete(int id);
        Fridge GetFridgeById(int id);
        public void Update(Fridge fridge);
    }
}
