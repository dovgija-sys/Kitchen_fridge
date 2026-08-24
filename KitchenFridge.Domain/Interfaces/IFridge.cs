namespace KitchenFridge.Domain.Interfaces
{
    public interface IFridge
    {
        public List<string> GetView();
        public void Add(IProduct product);
        public void Delete(string productName);
    }
}
