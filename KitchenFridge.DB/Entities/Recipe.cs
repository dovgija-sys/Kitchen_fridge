namespace KitchenFridge.DB.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<RecipeProduct> RecipeProducts { get; set; } = new();
    }
}
