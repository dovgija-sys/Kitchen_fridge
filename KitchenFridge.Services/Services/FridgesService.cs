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
                throw new ValidationException("Fridge name cann't contain specials");
            }
            return _fridgeRepository.Add(new Fridge { Name = createFridgeDTO.Name });
        }

        public void Update(UpdateFridgeDTO updateFridgeDTO)
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
                throw new ValidationException("Fridge name cann't contain specials");
            }
            var updateFridge = _fridgeRepository.GetFridgeById(updateFridgeDTO.Id);
            updateFridge.Name = updateFridgeDTO.Name;
            updateFridge.Id = updateFridgeDTO.Id;
            _fridgeRepository.Update(updateFridge);
        }
        public void Delete(int id)
        {
            _fridgeRepository.Delete(id);
        }
    }
}
