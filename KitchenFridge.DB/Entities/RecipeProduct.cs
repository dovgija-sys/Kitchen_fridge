
using KitchenFridge.DB.Entities.ProductEntities;

namespace KitchenFridge.DB.Entities
{
    public class RecipeProduct
    {
        public int Id { get; set; }
        public double Count { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

    }
}
