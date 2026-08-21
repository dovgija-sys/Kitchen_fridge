namespace KitchenFridge
{
    class EggsAndSauces : Product
    {
        public double Count { get; set; }
        public EggsAndSauces(string name, double count) : base(name)
        {
            IsValidNameOfProduct(name);
            IsValidCountOrWeight(count);
            Count = count;
        }
        public override string GetInfo()
        {
            return Name + " " + Count + "(pcs)";
        }
    }
}
