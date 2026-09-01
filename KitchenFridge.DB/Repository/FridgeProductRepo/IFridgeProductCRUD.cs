using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.FridgeProductRepo
{
    public interface IFridgeProductCRUD
    {
        public void Add(FridgeProduct fridgeProduct);
        public List<FridgeProduct> Get();
        public void Update(int id, FridgeProduct fridgeProduct);
        public bool Delete(int id);
    }
}
