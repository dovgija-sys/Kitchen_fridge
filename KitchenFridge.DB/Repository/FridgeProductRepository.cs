using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Repository.Interfaces;

namespace KitchenFridge.DB.Repository
{
    public class FridgeProductRepository : IFridgeProductRepository
    {
        private readonly KitchenFridgeContext _db;
        public FridgeProductRepository(KitchenFridgeContext db) => _db = db;
        public int Add(FridgeProduct fridgeProduct)
        {
            _db.FridgeProducts.Add(fridgeProduct);
            _db.SaveChanges();
            return fridgeProduct.Id;
        }
        public List<FridgeProduct> Get()
        {
            var fridgeProducts = _db.FridgeProducts.ToList();
            return fridgeProducts;
        }
        public void Update(int id, FridgeProduct fridgeProduct)
        {
            var updFridgeProduct = _db.FridgeProducts.FirstOrDefault(i=>i.Id == id);
            if(updFridgeProduct != null)
            {
                updFridgeProduct = fridgeProduct;
                _db.FridgeProducts.Update(updFridgeProduct);
                _db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var deleteFridgeProduct = _db.FridgeProducts.FirstOrDefault(i => i.Id == id);
            if (deleteFridgeProduct != null) 
            {
                _db.FridgeProducts.Remove(deleteFridgeProduct);
                _db.SaveChanges();
            }
        }
    }
}
