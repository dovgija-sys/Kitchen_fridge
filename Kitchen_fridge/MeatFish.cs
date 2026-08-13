using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFridge
{
    class MeatFish : Product
    {
        public double Weight { get; set; }
        public MeatFish(string name, double weight = 1) : base(name)
        {
            Weight = weight;
        }
        public override string GetInfo()
        {
            return Name + " " + Weight + "(kg)";
        }
    }
}
