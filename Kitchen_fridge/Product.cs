using System;
using System.Collections;
namespace KitchenFridge
{
    abstract class Product
    {
        public string? Name { get; set; }
        public Product(string? name) {
            Name = name;  
        }
        public virtual string GetInfo() => Name;
    }
}
