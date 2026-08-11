using System;
using System.Collections;

namespace KitchenFridge
{
    class Liquid : Product
    {
        public double Liter { get; set; }
        public Liquid(string name, double liter = 0.5) : base(name) 
        {
            Liter = liter;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"name: {Name}, liters: {Liter}(l)");
        }
    }
}
