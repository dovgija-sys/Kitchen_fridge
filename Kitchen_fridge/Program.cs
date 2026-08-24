using KitchenFridge.Domain;
using KitchenFridge.Domain.Products;

namespace KitchenFridge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fridge fridge = new Fridge();
            int choise;
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
                        foreach (var product in ListOfProducts)
                        {
                            Console.WriteLine($"{product}");
                        }
                        WaitMenu();
                        break;
                    case 2:
                        Console.WriteLine("\nPress 1 if you want to add liquid");
                        Console.WriteLine("Press 2 if you want to add meat or fish");
                        Console.WriteLine("Press 3 if you want to add dairy food");
                        Console.WriteLine("Press 4 if you want to add produse");
                        Console.WriteLine("Press 5 if you want to add eggs or sause");
                        Console.WriteLine("Press 0 to exit.\n");
                        Console.Write("Enter a number: ");
                        int choiseAdd = Convert.ToInt32(Console.ReadLine());
                        string? name;
                    repeat:
                        try
                        {
                            switch (choiseAdd)
                            {
                                case 0:
                                    break;
                                case 1:
                                    name = SetNameOfProduct();
                                    double valume = SetCountOfProduct();
                                    Product liquid = new Liquid(name, valume);
                                    fridge.Add(liquid);
                                    break;
                                case 2:
                                    name = SetNameOfProduct();
                                    double WeightOfMeat = SetCountOfProduct();
                                    Product meatfish = new MeatFish(name, WeightOfMeat);
                                    fridge.Add(meatfish);
                                    break;
                                case 3:
                                    name = SetNameOfProduct();
                                    double WeightOfDairy = SetCountOfProduct();
                                    Product dairy = new Dairy(name, WeightOfDairy);
                                    fridge.Add(dairy);
                                    break;
                                case 4:
                                    name = SetNameOfProduct();
                                    double WeightOfProduce = SetCountOfProduct();
                                    Product produce = new Produce(name, WeightOfProduce);
                                    fridge.Add(produce);
                                    break;
                                case 5:
                                    name = SetNameOfProduct();
                                    double CountOfEggsOrSauce = SetCountOfProduct();
                                    Product eggsAndSauces = new EggsAndSauces(name, CountOfEggsOrSauce);
                                    fridge.Add(eggsAndSauces);
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice.");
                                    break;
                            }
                        }
                        catch (ProductExceptions ex)
                        {
                            Console.WriteLine(ex.Message + " Please try again\n");
                            goto repeat;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format, please try again.\n");
                            goto repeat;
                        }
                        WaitMenu();
                        break;
                    case 3:
                        Console.Write("Enter name of the product you want to delete: ");
                        string productName = Console.ReadLine();
                        fridge.Delete(productName);
                        WaitMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;         
                }
                Console.Clear();
            } while (choise != 0);
        }
        static void WaitMenu()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static int GetOperation()
        {
            Console.WriteLine("Press 1 if you want to view the list of products.");
            Console.WriteLine("Press 2 if you want to add a product.");
            Console.WriteLine("Press 3 if you want to delete the product.");
            Console.WriteLine("Press 0 to exit.\n");
            Console.Write("Enter a number: ");
            int choise = Convert.ToInt32(Console.ReadLine());
            return choise;
        }
        static string SetNameOfProduct()
        {
            Console.Write("Enter name: ");
            string? name = Console.ReadLine();
            return name;
        }
        static double SetCountOfProduct()
        {
            Console.Write("Enter count(or value/weight): ");
            double count = Convert.ToDouble(Console.ReadLine());
            return count;   
        }
    }
}