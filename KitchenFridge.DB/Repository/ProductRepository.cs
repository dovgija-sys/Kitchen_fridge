using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;

namespace KitchenFridge.DB.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly KitchenFridgeContext _db;
        public ProductRepository(KitchenFridgeContext db) => _db = db;
        public void Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }
        public List<Product> GetNeededProducts(string productName)
        {
            var allProducts = _db.Products.ToList();
            var getNeededProducts = new List<Product>();
            foreach (var product in allProducts)
            {
                if (product.Name.ToLower() == productName.ToLower())
                {
                    getNeededProducts.Add(product);
                }
            }
            return getNeededProducts;
        }
        public List<Product> GetAllProducts()
        {
            var allProducts = _db.Products.ToList();
            return allProducts;
        }
        public Product GetConcreteProduct(int id)
        {
            var concreteProduct = _db.Products.FirstOrDefault(n => n.Id == id);
            return concreteProduct;
        }
        public void Update(int id, string newName) 
        {
            var updProduct = _db.Products.FirstOrDefault(n => n.Id == id);
            if (updProduct != null)
            {
                updProduct.Name = newName;
                _db.Products.Update(updProduct);
                _db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            var deleteProduct = _db.Products.FirstOrDefault(n => n.Id == id);
            if (deleteProduct != null)
            {
                _db.Products.Remove(deleteProduct);
                _db.SaveChanges();
                return true;
            }
            return false;  
        }
    }
}
