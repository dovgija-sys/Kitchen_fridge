namespace KitchenFridge
{
    class EggsAndSauces : IProduct
    {
        public string? Name { get; set; }
        public double Count { get; set; }
        public EggsAndSauces(string name, double count = 1)
        {
            Name = name;
            Count = count;
        }
        public string GetInfo()
        {
            return Name + " " + Count + "(pcs)";
        }
    }
}
