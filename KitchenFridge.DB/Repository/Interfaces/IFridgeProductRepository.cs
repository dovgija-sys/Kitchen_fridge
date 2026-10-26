using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IFridgeProductRepository
    {
        public Task<int> Add(FridgeProduct fridgeProduct);
        public Task<List<FridgeProduct>> Get();
        public Task Delete(int id);
        public Task<FridgeProduct> GetFridgeProductById(int id);
        public Task Update(FridgeProduct fridgeProduct);
    }
}
