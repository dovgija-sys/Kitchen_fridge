using KitchenFridge.DB.Entities.ProductEntities;

namespace KitchenFridge.DB.Entities
{
    public class FridgeProduct
    {
        public int Id { get; set; }
        public double Count { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int FridgeId { get; set; }
        public Fridge? Fridge { get; set; }
    }
}
