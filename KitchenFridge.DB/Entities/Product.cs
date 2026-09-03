namespace KitchenFridge.DB.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<FridgeProduct> FridgeProduct { get; set; } = new();
        public List<RecipeProduct> RecipeProduct { get; set; } = new();
    }
}
