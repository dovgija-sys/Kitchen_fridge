using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.ProductRepo
{
    public interface IProductCRUD
    {
        public void Add(Product product);
        public List<Product> GetNeededProducts(string productName);
        public List<Product> GetAllProducts();
        public Product GetConcreteProduct(int id);
        public void Update(int id, string newName);
        public bool Delete(int id);

    }
}
