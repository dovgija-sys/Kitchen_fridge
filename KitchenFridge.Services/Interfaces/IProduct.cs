namespace KitchenFridge.Services.Interfaces
{
    public interface IProduct
    {
        public string Name { get; set; }
        public string GetInfo();
    }
}
