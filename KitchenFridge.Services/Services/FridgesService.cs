using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;
using KitchenFridge.Services.DTOs;
using KitchenFridge.Services.Exceptions;
using KitchenFridge.Services.Interfaces;

namespace KitchenFridge.Services.Services
{
    public class FridgesService : IFridgesService
    {
        private readonly IFridgeRepository _fridgeRepository;
        public FridgesService(IFridgeRepository fridgeRepository)
        {
            _fridgeRepository = fridgeRepository;
        }

        public async Task<List<Fridge>> GetFridges()
        {
            return await _fridgeRepository.Get();
        }
        public async Task<Fridge> GetFridgeById(int id)
        {  
            return await _fridgeRepository.GetFridgeById(id);
        }

        public async Task<int> Add(CreateFridgeDTO createFridgeDTO)
        {
            if (string.IsNullOrEmpty(createFridgeDTO.Name))
            {
                throw new ValidationException("Fridge name can't be null or empty");
            }
            else if (createFridgeDTO.Name.Length > 20)
            {
                throw new ValidationException("Fridge name lenth is to be less than 20");
            }
            else if (createFridgeDTO.Name.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ValidationException("Fridge name can't contain specials");
            }
            return await _fridgeRepository.Add(new Fridge { Name = createFridgeDTO.Name });
        }

        public async Task Update(UpdateFridgeDTO updateFridgeDTO)
        {
            if(updateFridgeDTO.Id <= 0)
            {
                throw new ValidationException("Id can't be less than or equal to 0");
            }
            else if (string.IsNullOrEmpty(updateFridgeDTO.Name))
            {
                throw new ValidationException("Fridge name can't be null or empty");
            }
            else if (updateFridgeDTO.Name.Length > 20)
            {
                throw new ValidationException("Fridge name lenth is to be less than 20");
            }
            else if (updateFridgeDTO.Name.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ValidationException("Fridge name can't contain specials");
            }
            var updateFridge = await _fridgeRepository.GetFridgeById(updateFridgeDTO.Id);
            updateFridge.Name = updateFridgeDTO.Name;
            updateFridge.Id = updateFridgeDTO.Id;
            await _fridgeRepository.Update(updateFridge);
        }
        public async Task Delete(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Id can't be less than or equal to 0");
            }
            await _fridgeRepository.Delete(id);
        }
    }
}
