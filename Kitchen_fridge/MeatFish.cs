namespace KitchenFridge
{
    class MeatFish : IProduct
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public MeatFish(string name, double weight = 1)
        {
            Name = name;
            Weight = weight;
        }
        public string GetInfo()
        {
            return Name + " " + Weight + "(kg)";
        }
    }
}
