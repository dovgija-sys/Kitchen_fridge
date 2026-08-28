namespace KitchenFridge.Domain.Interfaces
{
    public interface IRecipe
    {
        public string Name { get; }
        public List<string> GetView();
        public void Add(IProduct product);
    }
}
