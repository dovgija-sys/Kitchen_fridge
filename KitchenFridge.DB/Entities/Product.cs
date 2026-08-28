namespace KitchenFridge.DB.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public FridgeProduct? FridgeProduct { get; set; }
        public RecipeProduct? RecipeProduct { get; set; }
    }
}
