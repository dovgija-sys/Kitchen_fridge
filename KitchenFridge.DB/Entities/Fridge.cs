namespace KitchenFridge.DB.Entities
{
    public class Fridge
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<FridgeProduct> FridgeProducts { get; set; } = [];
    }
}
