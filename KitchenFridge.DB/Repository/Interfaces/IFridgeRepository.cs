using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IFridgeRepository
    {
        public Task<int> Add(Fridge fridge);
        public Task<List<Fridge>> Get();
        public Task Delete(int id);
        public Task<Fridge> GetFridgeById(int id);
        public Task Update(Fridge fridge);
    }
}
