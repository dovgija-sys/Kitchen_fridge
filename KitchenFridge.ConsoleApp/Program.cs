using KitchenFridge.Domain;
using KitchenFridge.Domain.Products;
using KitchenFridge.DB;

namespace KitchenFridge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (KitchenFridgeContext db = new KitchenFridgeContext())
            {
                db.Database.EnsureDeleted();
                if (db.Database.EnsureCreated())
                {
                    Console.WriteLine("OK!!");
                }
            }
            var listOfRecipes = new List<RecipeBase>();
            FridgeBase fridge = new FridgeBase();
            int choise;
            do
            {
                choise = GetOperationForMeinMenu();
                switch (choise)
                {
                    case 0:
                        break;
                    case 1:
                        foreach (var product in fridge.GetView())
                        {
                            Console.WriteLine($"-{product}");
                        }
                        WaitMenu();
                        break;
                    case 2:
                        int choiseAddProduct = GetOperationForAddingProduct();
                        string? name;
                    repeat:
                        try
                        {
                            switch (choiseAddProduct)
                            {
                                case 0:
                                    break;
                                case 1:
                                    name = SetNameOfProduct();
                                    double valume = SetCountOfProduct();
                                    ProductBase liquid = new Liquid(name, valume);
                                    fridge.Add(liquid);
                                    break;
                                case 2:
                                    name = SetNameOfProduct();
                                    double WeightOfMeat = SetCountOfProduct();
                                    ProductBase meatfish = new MeatFish(name, WeightOfMeat);
                                    fridge.Add(meatfish);
                                    break;
                                case 3:
                                    name = SetNameOfProduct();
                                    double WeightOfDairy = SetCountOfProduct();
                                    ProductBase dairy = new Dairy(name, WeightOfDairy);
                                    fridge.Add(dairy);
                                    break;
                                case 4:
                                    name = SetNameOfProduct();
                                    double WeightOfProduce = SetCountOfProduct();
                                    ProductBase produce = new Produce(name, WeightOfProduce);
                                    fridge.Add(produce);
                                    break;
                                case 5:
                                    name = SetNameOfProduct();
                                    double CountOfEggsOrSauce = SetCountOfProduct();
                                    ProductBase eggsAndSauces = new EggsAndSauces(name, CountOfEggsOrSauce);
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
                    case 4:
                        Console.Write("Enter name of the recipe: ");
                        string recipeName = Console.ReadLine();
                        var recipe = new RecipeBase(recipeName);
                        Console.WriteLine("Enter the ingredients:");
                        var choiseAddIngredient = GetOperationForAddingProduct();
                        while (choiseAddIngredient != 0)
                        {
                        repeat2:
                            try
                            {
                                switch (choiseAddIngredient)
                                {
                                    case 1:
                                        name = SetNameOfProduct();
                                        double valume = SetCountOfProduct();
                                        var liquid = new Liquid(name, valume);
                                        recipe.Add(liquid);
                                        break;
                                    case 2:
                                        name = SetNameOfProduct();
                                        double WeightOfMeat = SetCountOfProduct();
                                        var meatfish = new MeatFish(name, WeightOfMeat);
                                        recipe.Add(meatfish);
                                        break;
                                    case 3:
                                        name = SetNameOfProduct();
                                        double WeightOfDairy = SetCountOfProduct();
                                        var dairy = new Dairy(name, WeightOfDairy);
                                        recipe.Add(dairy);
                                        break;
                                    case 4:
                                        name = SetNameOfProduct();
                                        double WeightOfProduce = SetCountOfProduct();
                                        var produce = new Produce(name, WeightOfProduce);
                                        recipe.Add(produce);
                                        break;
                                    case 5:
                                        name = SetNameOfProduct();
                                        double CountOfEggsOrSauce = SetCountOfProduct();
                                        var eggsAndSauces = new EggsAndSauces(name, CountOfEggsOrSauce);
                                        recipe.Add(eggsAndSauces);
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice.");
                                        break;
                                }
                                choiseAddIngredient = GetOperationForAddingProduct();
                            }
                            catch (ProductExceptions ex)
                            {
                                Console.WriteLine(ex.Message + " Please try again\n");
                                goto repeat2;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input format, please try again.\n");
                                goto repeat2;
                            }
                            listOfRecipes.Add(recipe);
                            WaitMenu();
                        }
                        break; 
                    case 5:
                        foreach (var rec in listOfRecipes)
                        {
                            Console.WriteLine($"Recipe: {rec.Name}");
                            Console.WriteLine("Ingredients:");
                            foreach (var ingredient in rec.GetView())
                            {
                                Console.WriteLine($"- {ingredient}");
                            }
                        }
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
        static int GetOperationForMeinMenu()
        {
            Console.WriteLine("Press 1 if you want to view the list of products.");
            Console.WriteLine("Press 2 if you want to add a product.");
            Console.WriteLine("Press 3 if you want to delete the product.");
            Console.WriteLine("Press 4 if you want to add the recipe.");
            Console.WriteLine("Press 5 if you want to view the list of recipes.");
            Console.WriteLine("Press 0 to exit.\n");
            Console.Write("Enter a number: ");
            int choise = Convert.ToInt32(Console.ReadLine());
            return choise;
        }
        static int GetOperationForAddingProduct()
        {
            Console.WriteLine("Press 1 if you want to add liquid");
            Console.WriteLine("Press 2 if you want to add meat or fish");
            Console.WriteLine("Press 3 if you want to add dairy food");
            Console.WriteLine("Press 4 if you want to add produse");
            Console.WriteLine("Press 5 if you want to add eggs or sause");
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