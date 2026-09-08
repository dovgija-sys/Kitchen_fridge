using KitchenFridge.DB;
using KitchenFridge.DB.Entities;
using KitchenFridge.DB.Entities.ProductEntities;
using KitchenFridge.DB.Repository;
using KitchenFridge.Domain;
using KitchenFridge.Domain.Products;

namespace KitchenFridge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (KitchenFridgeContext db = new())
            {
                var productCrud = new ProductRepository(db);
                var recipeCrud = new RecipeRepository(db);
                var recipeProductCrud = new RecipeProductRepository(db);
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                var product1 = new DB.Entities.ProductEntities.Liquid { Name = "Milk"};
                var product2 = new Product { Name = "Banana"};
                var recipe = new DB.Entities.Recipe { Name = "MilkShake" };
                productCrud.Add(product1);
                productCrud.Add(product2);
                recipeCrud.Add(recipe);
                var recipeProduct1 = new RecipeProduct { Product = product1, Count = 0.3, Recipe = recipe};
                var recipeProduct2 = new RecipeProduct { Product = product2, Count = 1, Recipe = recipe};
                recipeProductCrud.Add(recipeProduct1);
                recipeProductCrud.Add(recipeProduct2);
            }
            var listOfRecipes = new List<Domain.Recipe>();
            Domain.Fridge fridge = new();
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
                                    ProductBase liquid = new Domain.Products.Liquid(name, valume);
                                    fridge.Add(liquid);
                                    break;
                                case 2:
                                    name = SetNameOfProduct();
                                    double WeightOfMeat = SetCountOfProduct();
                                    ProductBase meatfish = new Domain.Products.MeatFish(name, WeightOfMeat);
                                    fridge.Add(meatfish);
                                    break;
                                case 3:
                                    name = SetNameOfProduct();
                                    double WeightOfDairy = SetCountOfProduct();
                                    ProductBase dairy = new Domain.Products.Dairy(name, WeightOfDairy);
                                    fridge.Add(dairy);
                                    break;
                                case 4:
                                    name = SetNameOfProduct();
                                    double WeightOfProduce = SetCountOfProduct();
                                    ProductBase produce = new Domain.Products.Produce(name, WeightOfProduce);
                                    fridge.Add(produce);
                                    break;
                                case 5:
                                    name = SetNameOfProduct();
                                    double CountOfEggsOrSauce = SetCountOfProduct();
                                    ProductBase eggsAndSauces = new Domain.Products.EggsAndSauces(name, CountOfEggsOrSauce);
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
                        var recipe = new Domain.Recipe(recipeName);
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
                                        var liquid = new Domain.Products.Liquid(name, valume);
                                        recipe.Add(liquid);
                                        break;
                                    case 2:
                                        name = SetNameOfProduct();
                                        double WeightOfMeat = SetCountOfProduct();
                                        var meatfish = new Domain.Products.MeatFish(name, WeightOfMeat);
                                        recipe.Add(meatfish);
                                        break;
                                    case 3:
                                        name = SetNameOfProduct();
                                        double WeightOfDairy = SetCountOfProduct();
                                        var dairy = new Domain.Products.Dairy(name, WeightOfDairy);
                                        recipe.Add(dairy);
                                        break;
                                    case 4:
                                        name = SetNameOfProduct();
                                        double WeightOfProduce = SetCountOfProduct();
                                        var produce = new Domain.Products.Produce(name, WeightOfProduce);
                                        recipe.Add(produce);
                                        break;
                                    case 5:
                                        name = SetNameOfProduct();
                                        double CountOfEggsOrSauce = SetCountOfProduct();
                                        var eggsAndSauces = new Domain.Products.EggsAndSauces(name, CountOfEggsOrSauce);
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