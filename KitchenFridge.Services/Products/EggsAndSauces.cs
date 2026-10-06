namespace KitchenFridge.Services.Products
{
    public class EggsAndSauces : ProductBase
    {
        public double Count { get; set; }
        public EggsAndSauces(string name, double count) : base(name)
        {
            IsValidCountOrWeight(count);
            Count = count;
        }
        public override string GetInfo()
        {
            return Name + " " + Count + "(pcs)";
        }
    }
}
