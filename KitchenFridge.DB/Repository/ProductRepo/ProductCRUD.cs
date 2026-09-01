using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.ProductRepo
{
    public class ProductCRUD : IProductCRUD
    {
        public void Add(Product product)
        {
            using var db = new KitchenFridgeContext();
            db.Products.Add(product);
            db.SaveChanges();
        }
        public List<Product> GetNeededProducts(string productName)
        {
            using var db = new KitchenFridgeContext();
            var allProducts = db.Products.ToList();
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
            using var db = new KitchenFridgeContext();
            var allProducts = db.Products.ToList();
            return allProducts;
        }
        public Product GetConcreteProduct(int id)
        {
            using var db = new KitchenFridgeContext();
            var concreteProduct = db.Products.FirstOrDefault(n => n.Id == id);
            return concreteProduct;
        }
        public void Update(int id, string newName) 
        {
            using var db = new KitchenFridgeContext();
            var updProduct = db.Products.FirstOrDefault(n => n.Id == id);
            if (updProduct != null)
            {
                updProduct.Name = newName;
                db.Products.Update(updProduct);
                db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            using var db = new KitchenFridgeContext();
            var deleteProduct = db.Products.FirstOrDefault(n => n.Id == id);
            if (deleteProduct != null)
            {
                db.Products.Remove(deleteProduct);
                db.SaveChanges();
                return true;
            }
            return false;  
        }
    }
}
