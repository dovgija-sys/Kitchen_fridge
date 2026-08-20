using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFridge
{
    class ProductNameException : Exception
    {
        public ProductNameException(string message) : base(message)
        {
        }
    }
    class ProductCountException : Exception
    {
        public ProductCountException(string message) : base(message)
        {
        }
    }
}
