using System;

namespace KitchenFridge
{
    class Program
    {
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
                    case 1:
                        fridge.View();
                        break;
                    case 2:
                        do
                        {
                            addChoise = fridge.Add();
                        } while (addChoise!=0);
                        break;
                    case 3:
                        Product prod = null;
                        fridge.Delete(prod);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (choise != 0);
        }
    }
}