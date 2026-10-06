using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IFridgeProductRepository
    {
        public int Add(FridgeProduct fridgeProduct);
        public List<FridgeProduct> Get();
        public void Update(int id, FridgeProduct fridgeProduct);
        public void Delete(int id);
    }
}
