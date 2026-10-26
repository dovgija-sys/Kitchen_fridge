using KitchenFridge.DB.Entities.ProductEntities;
using KitchenFridge.DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitchenFridge.DB.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly KitchenFridgeContext _db;
        public ProductRepository(KitchenFridgeContext db) => _db = db;
        public async Task<int> Add(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return product.Id;
        }
        public async Task<List<Product>> Get()
        {
            var allProducts = await _db.Products.ToListAsync();
            return allProducts;
        }
        public async Task<Product> GetProductById(int id)
        { 
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task Update(Product product) 
        {
            var updProduct = await _db.Products.FirstOrDefaultAsync(n => n.Id == product.Id);
            if (updProduct != null)
            {
                updProduct = product;
                _db.Products.Update(updProduct);
                await _db.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var deleteProduct = await _db.Products.FirstOrDefaultAsync(n => n.Id == id);
            if (deleteProduct != null)
            {
                _db.Products.Remove(deleteProduct);
                await _db.SaveChangesAsync();
            }
        }
    }
}
