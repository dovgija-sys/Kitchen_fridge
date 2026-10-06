
using KitchenFridge.Services.DTOs;

namespace KitchenFridge.Services.Interfaces
{
    public interface IFridgesService
    {
        public int Add(CreateFridgeDTO createFridgeDTO);
        void Delete(int id);
        public List<DB.Entities.Fridge> Get();
        DB.Entities.Fridge GetFridgeById(int id);
        void Update(UpdateFridgeDTO updateFridgeDTO);
    }
}