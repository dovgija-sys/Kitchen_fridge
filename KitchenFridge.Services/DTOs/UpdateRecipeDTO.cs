using KitchenFridge.Services.Interfaces;

namespace KitchenFridge.Services.DTOs
{
    public class UpdateRecipeDTO : CreateRecipeDTO
    {
        public int Id { get; set; }
    }
}
