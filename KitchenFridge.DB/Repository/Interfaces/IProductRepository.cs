using KitchenFridge.DB.Entities.ProductEntities;

namespace KitchenFridge.DB.Repository.Interfaces
{
    public interface IProductRepository
    {
        public Task<int> Add(Product product);
        public Task<List<Product>> Get();
        public Task Update(Product product);
        public Task Delete(int id);
        public Task<Product> GetProductById(int id);
    }
}
