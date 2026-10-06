using KitchenFridge.DB.Entities.ProductEntities;
using KitchenFridge.DB.Repository.Interfaces;

namespace KitchenFridge.DB.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly KitchenFridgeContext _db;
        public ProductRepository(KitchenFridgeContext db) => _db = db;
        public int Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return product.Id;
        }
        public List<Product> Get()
        {
            var allProducts = _db.Products.ToList();
            return allProducts;
        }
        public Product GetProductById(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }
        public void Update(Product product) 
        {
            var updProduct = _db.Products.FirstOrDefault(n => n.Id == product.Id);
            if (updProduct != null)
            {
                updProduct.Name = product.Name;
                updProduct.ProductType = product.ProductType;
                _db.Products.Update(updProduct);
                _db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var deleteProduct = _db.Products.FirstOrDefault(n => n.Id == id);
            if (deleteProduct != null)
            {
                _db.Products.Remove(deleteProduct);
                _db.SaveChanges();
            }
        }
    }
}
