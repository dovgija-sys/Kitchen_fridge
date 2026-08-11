using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFridge
{
    class Fridge
    {
        private List<Product> _Products = new List<Product>();
        public void View()
        {
            foreach (var product in _Products)
            {
                product.PrintInfo();
            }
        }
        public int Add()
        {
            Console.WriteLine("Press 1 if you want to add liquid");
            Console.WriteLine("Press 2 if you want to add meat or fish");
            Console.WriteLine("Press 3 if you want to add dairy food");
            Console.WriteLine("Press 4 if you want to add produse");
            Console.WriteLine("Press 5 if you want to add eggs or sause");
            Console.WriteLine("Press 0 to exit.\n");
            Console.Write("Enter a number: ");
            int choise = Convert.ToInt32(Console.ReadLine());
            string? name;
            switch (choise)
            {
                case 0:
                    break;
                case 1:
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter liters: ");
                    double liter = Convert.ToDouble(Console.ReadLine());
                    Product liquid = new Liquid(name, liter);
                    _Products.Add(liquid);
                    break;
                case 2:
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter weight: ");
                    double WeightOfMeat = Convert.ToDouble(Console.ReadLine());
                    Product meatfish = new MeatFish(name, WeightOfMeat);
                    _Products.Add(meatfish);
                    break;
                case 3:
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter weight: ");
                    double WeightOfDairy = Convert.ToDouble(Console.ReadLine());
                    Product dairy = new Dairy(name, WeightOfDairy);
                    _Products.Add(dairy);
                    break;
                case 4:
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter weight: ");
                    double WeightOfProduce = Convert.ToDouble(Console.ReadLine());
                    Product produce = new Produce(name, WeightOfProduce);
                    _Products.Add(produce);
                    break;
                case 5:
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter count: ");
                    double CountOfEggsOrSauce = Convert.ToDouble(Console.ReadLine());
                    Product eggsAndSauces = new EggsAndSauces(name, CountOfEggsOrSauce);
                    _Products.Add(eggsAndSauces);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            return choise;
        }
        public void Delete(Product prod)
        {
            Console.Write("Enter name of the product you want to delete: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            for (int i = 0; i < _Products.Count; i++)
            {
                var product = _Products[i];
                if (product != null && product.Name == name)
                {
                    _Products.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
