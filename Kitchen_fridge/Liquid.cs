namespace KitchenFridge
{
    class Liquid : IProduct
    {
        public string? Name { get; set; }
        public double Volume { get; set; }
        public Liquid(string name, double volume = 0.5)
        {
            Name = name;
            Volume = volume;
        }
        public string GetInfo()
        {
            return Name + " " + Volume + "(l)";
        }
    }
}
