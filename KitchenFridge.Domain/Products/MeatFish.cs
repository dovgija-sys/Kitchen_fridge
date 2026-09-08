namespace KitchenFridge.Domain.Products
{
    public class MeatFish : ProductBase
    {
        public double Weight { get; set; }
        public MeatFish(string name, double weight): base(name)
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
