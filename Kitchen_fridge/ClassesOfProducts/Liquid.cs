namespace KitchenFridge
{
    class Liquid : Product
    {
        public double Volume { get; set; }
        public Liquid(string name, double volume) : base(name)
        {
            IsValidNameOfProduct(name);
            IsValidCountOrWeight(volume);
            Volume = volume;
        }
        public override string GetInfo()
        {
            return Name + " " + Volume + "(l)";
        }
    }
}
