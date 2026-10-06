using KitchenFridge.DB.Entities.ProductEntities;
using KitchenFridge.Services.DTOs;

namespace KitchenFridge.Services.Interfaces
{
    public interface IProductsService
    {
        int Add(CreateProductDTO createProductDTO);
        void Delete(int id);
        Product GetProductById(int id);
        List<Product> GetProducts();
        void Update(UpdateProductDTO updateProductDTO);
    }
}