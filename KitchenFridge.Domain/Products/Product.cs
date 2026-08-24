using KitchenFridge.Domain.Interfaces;

namespace KitchenFridge.Domain.Products
{
    public abstract class Product : IProduct 
    {
        public string Name { get; set; }
        public Product(string name)
        {
            IsValidNameOfProduct(name);
            Name = name;
        }
        public virtual string GetInfo()
        {
            return Name;
        }
        public bool IsValidNameOfProduct(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ProductExceptions("Invalid product name. It cant be empty.");
            }
            else if (name.Length > 20)
            {
                throw new ProductExceptions("Invalid product name. It cant be more than 20.");
            }
            else if (name.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ProductExceptions("Invalid product name. It can only contain letters and digits.");
            }
            return true;
        }
        public bool IsValidCountOrWeight(double countOrWeight)
        {
            if (countOrWeight <= 0 || countOrWeight > 20)
            {
                throw new ProductExceptions("Invalid count(or value/weight). It must be greater than zero and no more than 20.");
            }
            return true;
        }
    }
}
