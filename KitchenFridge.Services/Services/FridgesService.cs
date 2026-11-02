using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;
using KitchenFridge.Services.DTOs;
using KitchenFridge.Services.Exceptions;
using KitchenFridge.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace KitchenFridge.Services.Services
{
    public class FridgesService : IFridgesService
    {
        private readonly IFridgeRepository _fridgeRepository;
        private readonly ILogger<FridgesService> _logger;
        public FridgesService(IFridgeRepository fridgeRepository, ILogger<FridgesService> logger)
        {
            _fridgeRepository = fridgeRepository;
            _logger = logger;
        }

        public async Task<List<Fridge>> GetFridges()
        {
            var fridges = await _fridgeRepository.Get();
            _logger.LogInformation("A list of all refrigerators has been compiled; quantity: {count}", fridges.Count());
            return fridges; 
        }
        public async Task<Fridge> GetFridgeById(int id)
        {
            var fridge = await _fridgeRepository.GetFridgeById(id);
            _logger.LogInformation("Retrieved from the database: refrigerator with ID {Id}, name: {Name}", fridge.Id, fridge.Name);
            return fridge;
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
            var id = await _fridgeRepository.Add(new Fridge { Name = createFridgeDTO.Name });
            _logger.LogInformation("Fridge has been created with ID: {ID}", id);
            return id;
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
            _logger.LogInformation("Fridge with ID {Id} has been updated, name: {Name}", updateFridge.Id, updateFridge.Name );
        }
        public async Task Delete(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Id can't be less than or equal to 0");
            }
            await _fridgeRepository.Delete(id);
            _logger.LogInformation("Fridge with ID: {Id} has been deleted", id);
        }
    }
}
