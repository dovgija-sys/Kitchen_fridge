using KitchenFridge.DB.Entities;

namespace KitchenFridge.DB.Repository.FridgeProductRepo
{
    public class FridgeProductCRUD : IFridgeProductCRUD
    {
        public void Add(FridgeProduct fridgeProduct)
        {
            using var db = new KitchenFridgeContext();
            db.FridgeProducts.Add(fridgeProduct);
            db.SaveChanges();
        }
        public List<FridgeProduct> Get()
        {
            using var db = new KitchenFridgeContext();
            var fridgeProducts = db.FridgeProducts.ToList();
            return fridgeProducts;
        }
        public void Update(int id, FridgeProduct fridgeProduct)
        {
            using var db = new KitchenFridgeContext();
            var updFridgeProduct = db.FridgeProducts.FirstOrDefault(i=>i.Id == id);
            if(updFridgeProduct != null)
            {
                updFridgeProduct = fridgeProduct;
                db.FridgeProducts.Update(updFridgeProduct);
                db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            using var db = new KitchenFridgeContext();
            var deleteFridgeProduct = db.FridgeProducts.FirstOrDefault(i => i.Id == id);
            if (deleteFridgeProduct != null) 
            {
                db.FridgeProducts.Remove(deleteFridgeProduct);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
