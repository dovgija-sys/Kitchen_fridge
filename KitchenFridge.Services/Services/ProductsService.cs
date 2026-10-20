using KitchenFridge.DB.Entities.ProductEntities;
using KitchenFridge.DB.Repository.Interfaces;
using KitchenFridge.Services.DTOs;
using KitchenFridge.Services.Interfaces;
using KitchenFridge.Services.Exceptions;
using Microsoft.VisualBasic;

namespace KitchenFridge.Services.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;

        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            var products = _productRepository.Get();
            return products;
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public int Add(CreateProductDTO createProductDTO)
        {

            var newProduct = new Product
            {
                Name = createProductDTO.Name,
                ProductType = createProductDTO.ProductType
            };
            return _productRepository.Add(newProduct);
        }
        public void Update(UpdateProductDTO updateProductDTO)
        {
            var updProduct = new DB.Entities.ProductEntities.Product
            {
                Id = updateProductDTO.Id,
                Name = updateProductDTO.Name,
                ProductType = updateProductDTO.ProductType
            };
            _productRepository.Update(updProduct);
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
