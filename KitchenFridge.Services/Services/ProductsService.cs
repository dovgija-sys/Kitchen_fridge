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
            var newProduct = new Product
            {
                Name = createProductDTO.Name,
                ProductType = createProductDTO.ProductType
            };
            return _productRepository.Add(newProduct);
        }
        public void Update(UpdateProductDTO updateProductDTO)
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
            var updateProduct = _productRepository.GetProductById(updateProductDTO.Id);
            updateProduct.Name = updateProductDTO.Name;
            updateProduct.Id = updateProductDTO.Id;
            _productRepository.Update(updateProduct);
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
