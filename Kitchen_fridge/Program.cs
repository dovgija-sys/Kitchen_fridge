using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Xml.Linq;
namespace KitchenFridge
{
    class Program
    {
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
                        foreach (var product in ListOfProducts)
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
                    repeat:
                        try
                        {
                            switch (ChoiseAdd)
                            {
                                case 0:
                                    break;
                                case 1:
                                    name = SetNameOfProduct();
                                    double value = SetCountOfProduct();
                                    IProduct liquid = new Liquid(name, value);
                                    fridge.Add(liquid);
                                    break;
                                case 2:
                                    name = SetNameOfProduct();
                                    double WeightOfMeat = SetCountOfProduct();
                                    IProduct meatfish = new MeatFish(name, WeightOfMeat);
                                    fridge.Add(meatfish);
                                    break;
                                case 3:
                                    name = SetNameOfProduct();
                                    double WeightOfDairy = SetCountOfProduct();
                                    IProduct dairy = new Dairy(name, WeightOfDairy);
                                    fridge.Add(dairy);
                                    break;
                                case 4:
                                    name = SetNameOfProduct();
                                    double WeightOfProduce = SetCountOfProduct();
                                    IProduct produce = new Produce(name, WeightOfProduce);
                                    fridge.Add(produce);
                                    break;
                                case 5:
                                    name = SetNameOfProduct();
                                    double CountOfEggsOrSauce = SetCountOfProduct();
                                    IProduct eggsAndSauces = new EggsAndSauces(name, CountOfEggsOrSauce);
                                    fridge.Add(eggsAndSauces);
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice.");
                                    break;
                            }
                        }
                        catch (ProductNameException ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto repeat;
                        }
                        catch (ProductCountException ex) 
                        {
                            Console.WriteLine(ex.Message);
                            goto repeat;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format. Please enter a valid number.");
                            goto repeat;
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
            IsValidNameOfProduct(name);
            return name;
        }
        static double SetCountOfProduct()
        {
            Console.Write("Enter count(or value/weight): ");
            double count = Convert.ToDouble(Console.ReadLine());
            IsValidCountOrWeight(count);
            return count;   
        }
        static bool IsValidNameOfProduct(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ProductNameException("Invalid product name. It cant be empty.");
            }
            else if(name.Length > 20)
            {
                throw new ProductNameException("Invalid product name. It cant be more than 20.");
            }
            else if (name.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ProductNameException("Invalid product name. It can only contain letters and digits.");
            }
            return true;
        }
        static bool IsValidCountOrWeight(double countOrWeight)
        {
            if (countOrWeight <= 0 || countOrWeight > 20)
            {
                throw new ProductCountException("Invalid count(or value/weight). It must be greater than zero and no more than 20.");
            }
            return true;
        }
    }
}