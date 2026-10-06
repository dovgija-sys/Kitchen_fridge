using KitchenFridge.Services.Interfaces;

namespace KitchenFridge.Services
{
    public class Recipe : IRecipe
    {
        private List<IProduct> _Ingredients = new List<IProduct>();
        public string Name { get; set; }
        public Recipe(string name)
        {
            Name = name;
        }
        public List<string> GetView()
        {
            List<string> products = new List<string>();
            foreach (var product in _Ingredients)
            {
                products.Add(product.GetInfo());
            }
            return products;
        }
        public void Add(IProduct product)
        {
            _Ingredients.Add(product);
        }
    }
}
