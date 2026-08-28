using KitchenFridge.Domain.Interfaces;
using KitchenFridge.Domain.Products;

namespace KitchenFridge.Domain
{
    public class RecipeBase : IRecipe
    {
        private List<IProduct> _Ingredients = new List<IProduct>();
        public string Name { get; set; }
        public RecipeBase(string name)
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
