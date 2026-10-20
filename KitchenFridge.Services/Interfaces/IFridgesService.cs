
using KitchenFridge.DB.Entities;
using KitchenFridge.Services.DTOs;

namespace KitchenFridge.Services.Interfaces
{
    public interface IFridgesService
    {
        public int Add(CreateFridgeDTO createFridgeDTO);
        void Delete(int id);
        public List<Fridge> Get();
        public Fridge GetFridgeById(int id);
        void Update(UpdateFridgeDTO updateFridgeDTO);
    }
}