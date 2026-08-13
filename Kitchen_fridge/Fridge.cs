using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFridge
{
    class Fridge
    {
        private List<Product> _Products = new List<Product>();
        public List<string> GetView()
        {
            List<string> products = new List<string>();
            foreach (var product in _Products)
            {
                products.Add(product.GetInfo());
            }
            return products;
        }
        public void Add(Product product)
        {
            _Products.Add(product);
        }
        public void Delete(string? ProductName)
        {
            if (string.IsNullOrEmpty(ProductName))
            {
                return;
            }
            for (int i = 0; i < _Products.Count; i++)
            {
                var product = _Products[i];
                if (product != null && product.Name == ProductName)
                {
                    _Products.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
