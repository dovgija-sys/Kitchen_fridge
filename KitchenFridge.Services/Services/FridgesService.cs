using KitchenFridge.Services.Interfaces;
using KitchenFridge.DB.Entities;
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

        public List<Fridge> Get()
        {
            return _fridgeRepository.Get();
        }
        public Fridge GetFridgeById(int id)
        {  
            return _fridgeRepository.GetFridgeById(id);
        }

        public int Add(CreateFridgeDTO createFridgeDTO)
        {
            return _fridgeRepository.Add(new Fridge { Name = createFridgeDTO.Name });
        }

        public void Update(UpdateFridgeDTO updateFridgeDTO)
        {
            
            _fridgeRepository.Update(new Fridge { Id = updateFridgeDTO.Id, 
                                                  Name = updateFridgeDTO.Name});
        }
        public void Delete(int id)
        {
            _fridgeRepository.Delete(id);
        }
    }
}
