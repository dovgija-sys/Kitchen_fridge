using KitchenFridge.DB.Entities.ProductEntities;
using KitchenFridge.DB.Repository;
using KitchenFridge.DB.Repository.Interfaces;
using KitchenFridge.Services.DTOs;
using KitchenFridge.Services.Exceptions;
using KitchenFridge.Services.Interfaces;

namespace KitchenFridge.Services.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;

        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.Get(); ;
        }
        public async Task<Product> GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Id can't be less than or equal to 0");
            }
            return await _productRepository.GetProductById(id);
        }

        public async Task<int> Add(CreateProductDTO createProductDTO)
        {
            if (string.IsNullOrEmpty(createProductDTO.Name))
            {
                throw new ValidationException("Product name can't be null or empty");
            }
            else if (createProductDTO.Name.Length > 20)
            {
                throw new ValidationException("Product name lenth is to be less than 20");
            }
            else if (createProductDTO.Name.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ValidationException("Product name can't contain specials");
            }
            return await _productRepository.Add(new Product {Name = createProductDTO.Name});
        }
        public async Task Update(UpdateProductDTO updateProductDTO)
        {
            if (updateProductDTO.Id <= 0)
            {
                throw new ValidationException("Id can't be less than or equal to 0");
            }
            else if (string.IsNullOrEmpty(updateProductDTO.Name))
            {
                throw new ValidationException("Product name can't be null or empty");
            }
            else if (updateProductDTO.Name.Length > 20)
            {
                throw new ValidationException("Product name lenth is to be less than 20");
            }
            else if (updateProductDTO.Name.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ValidationException("Product name can't contain specials");
            }
            var updateProduct = await _productRepository.GetProductById(updateProductDTO.Id);
            updateProduct.Name = updateProductDTO.Name;
            updateProduct.Id = updateProductDTO.Id;
            await _productRepository.Update(updateProduct);
        }
        public async Task Delete(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Id can't be less than or equal to 0");
            }
            await _productRepository.Delete(id);
        }
    }
}
