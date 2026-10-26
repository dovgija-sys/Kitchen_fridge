
using KitchenFridge.DB.Entities;
using KitchenFridge.Services.DTOs;

namespace KitchenFridge.Services.Interfaces
{
    public interface IFridgesService
    {
        public Task<int> Add(CreateFridgeDTO createFridgeDTO);
        public Task Delete(int id);
        public Task<List<Fridge>> Get();
        public Task<Fridge> GetFridgeById(int id);
        public Task Update(UpdateFridgeDTO updateFridgeDTO);
    }
}