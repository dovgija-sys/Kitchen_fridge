using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFridge
{
    class Dairy : Product
    {
        public double Weight { get; set; }
        public Dairy(string name, double weight = 1) : base(name)
        {
            Weight = weight;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"name: {Name}, weight: {Weight}(kg)");
        }
    }
}
