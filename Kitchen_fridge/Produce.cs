using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFridge
{
    class Produce : Product
    {
        public double Weight { get; set; }
        public Produce(string name, double weight = 1) : base(name)
        {
            Weight = weight;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"name: {Name}, weight: {Weight}(kg)");
        }
    }
}
