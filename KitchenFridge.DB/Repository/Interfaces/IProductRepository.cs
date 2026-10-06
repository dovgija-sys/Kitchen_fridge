using KitchenFridge.DB.Entities.ProductEntities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IProductRepository
    {
        public int Add(Product product);
        public List<Product> Get();
        public void Update(Product product);
        public void Delete(int id);
        Product GetProductById(int id);
    }
}
