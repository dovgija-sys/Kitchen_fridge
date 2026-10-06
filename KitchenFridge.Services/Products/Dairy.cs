namespace KitchenFridge.Services.Products
{
    public class Dairy : ProductBase
    {
        public double Weight { get; set; }
        public Dairy(string name, double weight) : base(name)
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
