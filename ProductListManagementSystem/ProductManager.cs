using ProductListManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductListManagementSystem
{
    public class ProductManager : IProductManager
    {
        List<Product> Products = new List<Product>();

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string? Name { get; set; }

        ///// <summary>
        ///// Gets or sets the price.
        ///// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Sets the category for the product.
        /// </summary>
        /// <returns>The category name.</returns>
        public string SetProductCategory()
        {
            // Get category name from user input
            Console.WriteLine("Enter category name");
            string? categoryName = Console.ReadLine();

            while (categoryName == null || categoryName == "" || categoryName == "r")
            {
                if (categoryName == "r")
                {
                    // Break input and return to main menu 
                    return ("r");
                }

                ColoredText.WriteLine("Invalid category name.", ConsoleColor.Red);
                Console.WriteLine("Enter category name:");
                categoryName = Console.ReadLine();
            }


            return categoryName;
        }

        /// <summary>
        /// Sets the name for the product.
        /// </summary>
        /// <returns>The product name.</returns>
        public string SetProductName()
        {
            // Get product name from user input
            Console.WriteLine("Enter product name");
            string? productName = Console.ReadLine();
            while (productName == null || productName == "" || productName == "r")
            {
                if (productName == "r")
                {
                    // Break input and return to main menu 
                    return ("r");
                }
                ColoredText.WriteLine("Invalid product name.", ConsoleColor.Red);
                Console.WriteLine("Enter product name:");
                productName = Console.ReadLine();
            }
            return productName;
        }

        /// <summary>
        /// Sets the price for the product.
        /// </summary>
        /// <returns>The product price.</returns>
        public decimal SetProductPrice()
        {
            while (true)
            {
                Console.Write("Enter a value: ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                    continue; // repeat until non-empty

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    return (-1);

                }

                if (decimal.TryParse(input, out decimal number))
                {
                    if (number >= 0)
                    {
                        // number is valid and >= 0 — proceed
                        Console.WriteLine($"Price are: {number}");

                        return (number);
                    }
                    else
                    {
                        ColoredText.WriteLine("Please enter a price that is 0 or greater.", ConsoleColor.Red);
                    }
                }
                else
                {
                    ColoredText.WriteLine("Invalid number format. Please try again.", ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Adds a new product to the list.
        /// </summary>
        public void AddProduct()
        {
            ColoredText.WriteLine("Add a Product", ConsoleColor.Yellow);

            Product newProduct = new Product("", "", 0.0m);
            string categoryName = SetProductCategory();
            if (categoryName == "exit")
            {
                return;
            }
            newProduct.Category = categoryName;

            string productName = SetProductName();
            if (productName == "exit")
            {
                return;
            }
            newProduct.Name = productName;

            decimal productPrice = SetProductPrice();
            if (productPrice == -1)
            {
                return;
            }
            newProduct.Price = productPrice;

            Products.Add(newProduct);
        }

        /// <summary>
        /// Searches for a product in the list.
        /// </summary>
        public void SearchProduct()
        {
            ColoredText.WriteLine("Search for product", ConsoleColor.Yellow);

            Console.WriteLine("Enter C for Category N for Name or Q to retun to meny");

            while (true)
            {
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                    continue; // repeat until non-empty

                if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    return;

                if (input.Equals("C", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.Equals(input, "C", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Enter a category: ");
                    }
                    else
                    {
                        Console.Write("Enter a product name: ");
                    }
                    string? term = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(term))
                    {
                        Console.WriteLine("Invalid search term.");
                        continue;
                    }

                    List<Product> found;
                    if (input.Equals("C", StringComparison.OrdinalIgnoreCase))
                    {
                        found = Products.FindAll(p => p.Category.Equals(term, StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine("Found products by category:");
                    }
                    else // input == "N"
                    {
                        found = Products.FindAll(p => p.Name.Equals(term, StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine("Found products by name:");
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var product in found)
                    {
                        Console.WriteLine($"Found: {product.Name} ({product.Category}): ${product.Price:F2}");
                    }
                    Console.ResetColor();

                    if (found.Count == 0)
                    {
                        Console.WriteLine("No products found.");
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter 'C' for Category or 'N' for Name.");
                }
            }
        }

        /// <summary>
        /// Lists all products in the inventory.
        /// </summary>
        public void ListProducts()
        {
            ColoredText.WriteLine("List Products", ConsoleColor.Yellow);
            foreach (var product in Products)
            {
                Console.WriteLine($"- {product.Name} ({product.Category}): ${product.Price:F2}");
            }
            ColoredText.WriteLine("------------------------", ConsoleColor.Yellow);
            decimal totalPrice = Products.Sum(p => p.Price);
            ColoredText.WriteLine($"Total Price: ${totalPrice:F2}", ConsoleColor.Green);
            ColoredText.WriteLine("------------------------", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Removes a product from the inventory.
        /// </summary>
        public void RemoveProduct()
        {
            ColoredText.WriteLine("Remove a Product", ConsoleColor.Yellow);
            Console.WriteLine("Enter the name of the product to remove:");
            string? productName = Console.ReadLine();
            if (string.IsNullOrEmpty(productName))
            {
                Console.WriteLine("Invalid product name.");
                return;
            }
            Product? productToRemove = Products.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
                Console.WriteLine($"Product '{productToRemove.Name}' removed successfully.");
            }
            else
            {
                Console.WriteLine($"Product '{productName}' not found.");
            }
        }

        /// <summary>
        /// Updates an existing product in the inventory.
        /// </summary> 
        public void UpdateProduct()
        {
            ColoredText.WriteLine("Update a Product", ConsoleColor.Yellow);
            Console.WriteLine("Enter the name of the product to update:");
            string? productName = Console.ReadLine();
            if (string.IsNullOrEmpty(productName))
            {
                Console.WriteLine("Invalid product name.");
                return;
            }
            Product? productToUpdate = Products.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (productToUpdate != null)
            {
                Console.WriteLine($"Updating product '{productToUpdate.Name}'");
                string newCategory = SetProductCategory();
                if (newCategory != "exit" || newCategory != null)
                {
                    productToUpdate.Category = newCategory;
                }
                string newName = SetProductName();
                if (newName != "exit" || newName != null)
                {
                    productToUpdate.Name = newName;
                }
                decimal newPrice = SetProductPrice();
                if (newPrice != -1 || newPrice > 0)
                {
                    productToUpdate.Price = newPrice;
                }
                Console.WriteLine($"Product '{productToUpdate.Name}' updated successfully.");
            }
            else
            {
                Console.WriteLine($"Product '{productName}' not found.");
            }
        }

        /// <summary>
        /// Shows statistics about the products in the inventory.
        /// 
        public void ShowStatistics()
        {
            ColoredText.WriteLine("Show Statistics", ConsoleColor.Yellow);
            Console.WriteLine($"Total products: {Products.Count}");

            Statistics statistics = new Statistics();
            string totalPrice = statistics.GetTotalPrice(Products);
            if (totalPrice != null)
            {
                Console.WriteLine($"Total Price: {totalPrice}");
            }
            else
            {
                Console.WriteLine("No products available.");
            }

            string highestProduct = statistics.GetHighestNumber(Products);
            if (highestProduct != null)
            {
                Console.WriteLine($"Highest product number: {highestProduct}");
            }
            else
            {
                Console.WriteLine("No products available.");
            }

            string lowestProduct = statistics.GetLowestNumber(Products);
            if (lowestProduct != null)
            {
                Console.WriteLine($"Lowest product number: {lowestProduct}");
            }
            else
            {
                Console.WriteLine("No products available.");
            }
        }

        /// <summary>
        /// Saves the products to a file.
        /// </summary>
        public void SaveProducts()
        {
            FileHandler handler = new FileHandler();
            handler.Save(Products);
        }

        /// <summary>
        /// Loads the products from a file.
        /// </summary>
        public void LoadProducts()
        {
            FileHandler handler = new FileHandler();
            Products = handler.Load();
        }
    }
}
