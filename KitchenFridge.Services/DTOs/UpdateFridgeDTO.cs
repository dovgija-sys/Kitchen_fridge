using KitchenFridge.Services.Interfaces;

namespace KitchenFridge.Services.DTOs
{
    public class UpdateFridgeDTO : CreateFridgeDTO
    {
        public int Id { get; set; }
    }
}
