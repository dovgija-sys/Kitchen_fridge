using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IFridgeProductRepository
    {
        public void Add(FridgeProduct fridgeProduct);
        public List<FridgeProduct> Get();
        public void Update(int id, FridgeProduct fridgeProduct);
        public bool Delete(int id);
    }
}
