namespace KitchenFridge.Services.Products
{
    public class Produce : ProductBase
    {
        public double Weight { get; set; }
        public Produce(string name, double weight) : base(name)
        {
            IsValidCountOrWeight(weight);
            Weight = weight;
        }
        public override string GetInfo()
        {
            return Name + " " + Weight + "(kg)";
        }
    }
}
