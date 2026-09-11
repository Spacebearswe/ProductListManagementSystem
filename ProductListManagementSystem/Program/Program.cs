using ProductListManagementSystem;

internal class Program
{
    public static void Main()
    {
        ProductManager productManager = new ProductManager();
        Program program = new Program();
        program.MainMenu(productManager);
    }

    public void MainMenu(ProductManager productManager)
    {
        bool doRun = true;
        while (doRun)
        {
            Console.Clear();
            ColoredText.WriteLine("Product Management System", ConsoleColor.Yellow);
            Console.WriteLine("");
            Console.WriteLine("Enter a Number");
            Console.WriteLine("1-Add a Product");
            Console.WriteLine("2-Search a Product");
            Console.WriteLine("3-List Products");
            Console.WriteLine("4-Remove Product");
            Console.WriteLine("5-Update Product");
            Console.WriteLine("6-Show Statistics");
            Console.WriteLine("7-Load Products");
            Console.WriteLine("8-Save Products");
            Console.WriteLine("0-Quit");

            Console.Write("Enter a Number ");
            string? userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    productManager.AddProduct();
                    break;
                case "2":
                    productManager.SearchProduct();
                    break;
                case "3":
                    productManager.ListProducts();
                    break;
                case "4":
                     productManager.RemoveProduct();
                     break;
                case "5":
                    productManager.UpdateProduct();
                    break;
                case "6":
                    productManager.ShowStatistics();
                    break;
                case "7":
                    productManager.LoadProducts();
                    break;
                case "8":
                    productManager.SaveProducts();
                    break;
                case "0":
                    Console.WriteLine("Thank you for using this application");
                    doRun = false;
                    break;

                default:
                    Console.WriteLine("Invalid Selection");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

    }
}
