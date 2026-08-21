namespace KitchenFridge
{
    class Produce : Product
    {
        public double Weight { get; set; }
        public Produce(string name, double weight) : base(name)
        {
            IsValidNameOfProduct(name);
            IsValidCountOrWeight(weight);
            Weight = weight;
        }
        public override string GetInfo()
        {
            return Name + " " + Weight + "(kg)";
        }
    }
}
