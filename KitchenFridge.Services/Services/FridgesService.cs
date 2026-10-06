using KitchenFridge.Services.Interfaces;
using KitchenFridge.DB.Repository;
using KitchenFridge.DB.Repository.Interfaces;
using KitchenFridge.Services.DTOs;

namespace KitchenFridge.Services.Services
{
    public class FridgesService : IFridgesService
    {
        private readonly IFridgeRepository _fridgeRepository;

        public FridgesService(IFridgeRepository fridgeRepository)
        {
            _fridgeRepository = fridgeRepository;
        }

        public List<DB.Entities.Fridge> Get()
        {
            return _fridgeRepository.Get();
        }
        public DB.Entities.Fridge GetFridgeById(int id)
        {
            return _fridgeRepository.GetFridgeById(id);
        }

        public int Add(CreateFridgeDTO createFridgeDTO)
        {
            var newFridge = new DB.Entities.Fridge
            {
                Name = createFridgeDTO.Name
            };
            return _fridgeRepository.Add(newFridge);
        }

        public void Update(UpdateFridgeDTO updateFridgeDTO)
        {
            var updFridge = new DB.Entities.Fridge
            {
                Id = updateFridgeDTO.Id,
                Name = updateFridgeDTO.Name
            };
            _fridgeRepository.Update(updFridge);
        }
        public void Delete(int id)
        {
            _fridgeRepository.Delete(id);
        }
    }
}
