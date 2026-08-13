using System;
using System.Collections;

namespace KitchenFridge
{
    class Liquid : Product
    {
        public double Volume { get; set; }
        public Liquid(string name, double liter = 0.5) : base(name) 
        {
            Volume = liter;
        }
        public override string GetInfo()
        {
            return Name + " " + Volume +"(l)";
        }
    }
}
