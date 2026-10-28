using KitchenFridge.DB.Entities.ProductEntities;
using KitchenFridge.Services.DTOs;

namespace KitchenFridge.Services.Interfaces
{
    public interface IProductsService
    {
        public Task<int> Add(CreateProductDTO createProductDTO);
        public Task Delete(int id);
        public Task<Product> GetProductById(int id);
        public Task<List<Product>> GetProducts();
        public Task Update(UpdateProductDTO updateProductDTO);
    }
}