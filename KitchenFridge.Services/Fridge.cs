using KitchenFridge.Services.Interfaces;

namespace KitchenFridge.Services
{
    public class Fridge : IFridge
    {
        private List<IProduct> _Products = [];
        public List<string> GetView()
        {
            List<string> products = new List<string>();
            foreach (var product in _Products)
            {
                products.Add(product.GetInfo());
            }
            return products;
        }
        public void Add(IProduct product)
        {
            _Products.Add(product);
        }
        public void Delete(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                return;
            }
            for (int i = 0; i < _Products.Count; i++)
            {
                var product = _Products[i];
                if (product != null && product.Name == productName)
                {
                    _Products.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
