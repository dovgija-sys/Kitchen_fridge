using System;

namespace KitchenFridge
{
    class Program
    {
        static void WaitMenu()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static int GetOperation() {
            Console.WriteLine("Press 1 if you want to view the list of products.");
            Console.WriteLine("Press 2 if you want to add a product.");
            Console.WriteLine("Press 3 if you want to delete the product.");
            Console.WriteLine("Press 0 to exit.\n");
            Console.Write("Enter a number: ");
            int choise = Convert.ToInt32(Console.ReadLine());
            return choise;
        }     
        static void Main(string[] args)
        {
            Fridge fridge = new Fridge();
            int choise, addChoise;
            do
            {
                choise = GetOperation();
                switch (choise)
                {
                    case 0:
                        break;
                    case 1:
                        List<string> ListOfProducts = new List<string>();
                        ListOfProducts = fridge.GetView();
                        foreach(var product in ListOfProducts)
                        {
                            Console.WriteLine($"{product}");
                        }
                        WaitMenu();
                        break;
                    case 2:
                        Console.WriteLine("Press 1 if you want to add liquid");
                        Console.WriteLine("Press 2 if you want to add meat or fish");
                        Console.WriteLine("Press 3 if you want to add dairy food");
                        Console.WriteLine("Press 4 if you want to add produse");
                        Console.WriteLine("Press 5 if you want to add eggs or sause");
                        Console.WriteLine("Press 0 to exit.\n");
                        Console.Write("Enter a number: ");
                        int ChoiseAdd = Convert.ToInt32(Console.ReadLine());
                        string? name;
                            switch (ChoiseAdd)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.Write("Enter name: ");
                                    name = Console.ReadLine();
                                    Console.Write("Enter liters: ");
                                    double liter = Convert.ToDouble(Console.ReadLine());
                                    Product liquid = new Liquid(name, liter);
                                    fridge.Add(liquid);
                                    break;
                                case 2:
                                    Console.Write("Enter name: ");
                                    name = Console.ReadLine();
                                    Console.Write("Enter weight: ");
                                    double WeightOfMeat = Convert.ToDouble(Console.ReadLine());
                                    Product meatfish = new MeatFish(name, WeightOfMeat);
                                    fridge.Add(meatfish);
                                    break;
                                case 3:
                                    Console.Write("Enter name: ");
                                    name = Console.ReadLine();
                                    Console.Write("Enter weight: ");
                                    double WeightOfDairy = Convert.ToDouble(Console.ReadLine());
                                    Product dairy = new Dairy(name, WeightOfDairy);
                                    fridge.Add(dairy);  
                                    break;
                                case 4:
                                    Console.Write("Enter name: ");
                                    name = Console.ReadLine();
                                    Console.Write("Enter weight: ");
                                    double WeightOfProduce = Convert.ToDouble(Console.ReadLine());
                                    Product produce = new Produce(name, WeightOfProduce);
                                fridge.Add(produce);
                                    break;
                                case 5:
                                    Console.Write("Enter name: ");
                                    name = Console.ReadLine();
                                    Console.Write("Enter count: ");
                                    double CountOfEggsOrSauce = Convert.ToDouble(Console.ReadLine());
                                    Product eggsAndSauces = new EggsAndSauces(name, CountOfEggsOrSauce);
                                    fridge.Add(eggsAndSauces);
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice.");
                                    break;
                            }
                        WaitMenu();
                        break;
                    case 3:
                        Console.Write("Enter name of the product you want to delete: ");
                        string? ProductName = Console.ReadLine();
                        fridge.Delete(ProductName);
                        WaitMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.Clear();
            } while (choise != 0);
        }
    }
}