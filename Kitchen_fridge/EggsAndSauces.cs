using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFridge
{
    class EggsAndSauces : Product
    {
        public double Count { get; set; }
        public EggsAndSauces(string name, double count = 1) : base(name)
        {
            Count = count;
        }
        public override string GetInfo()
        {
            return Name + " " + Count + "(pcs)";
        }
    }
}
