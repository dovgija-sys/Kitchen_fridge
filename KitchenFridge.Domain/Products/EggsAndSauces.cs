namespace KitchenFridge.Domain.Products
{
    public class EggsAndSauces : Product
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
