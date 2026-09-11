using ProductListManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ProductListManagementSystem
{
    public class FileHandler : IFileHandler
    {
        string fileName = string.Format(@"{0}\ProductList.json", Environment.CurrentDirectory);

        /// <summary>
        /// saves the list of products to a JSON file
        /// </summary>
        /// <param name="products"></param>
        public void Save(List<Product> products)
        {
            //Tries to save the list in a JSON file
            try
            {
                string jsonString = JsonSerializer.Serialize(products);
                File.WriteAllText(fileName, jsonString);
                ColoredText.WriteLine("Your product list has been saved", ConsoleColor.Green);
            }
            catch (Exception)
            {
                ColoredText.WriteLine("Failed to save product list!", ConsoleColor.Red);
            }

        }

        /// <summary>
        /// Opens the saved product list or creates a new one.
        /// </summary>
        /// <returns></returns>
        public List<Product> Open()
        {
            //If a file exists, load it. Otherwise, create a sample list of tasks.
            if (File.Exists(fileName)) return Load();
            else return CreateFirstTimeList();
        }

        /// <summary>
        /// Loads the products from a file.
        /// </summary>
        /// <returns>Loads the products in the List<Product></returns>
        public List<Product> Load()
        {
            try
            {
                string jsonString = File.ReadAllText(fileName);

                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    ColoredText.WriteLine("Saved file empty. Creating sample list\n", ConsoleColor.Yellow);
                    return CreateFirstTimeList();
                }

                var products = JsonSerializer.Deserialize<List<Product>>(jsonString)
                               ?? new List<Product>();

                ColoredText.WriteLine("Opened your saved list\n", ConsoleColor.Green);
                return products;
            }
            catch (Exception)
            {
                ColoredText.WriteLine("Failed to open saved To-Do List\n", ConsoleColor.Red);
                return CreateFirstTimeList();
            }
        }

        public List<Product> CreateFirstTimeList()
        {
            //Create a populated list of tasks
            List<Product> Products = [
                new Product("Milk", "Dairy", 2.5m),
                new Product("Bread", "Bakery", 1.5m),
                new Product("Eggs", "Dairy", 3.0m),
                new Product("Apples", "Fruit", 0.5m),
                new Product("Chicken", "Meat", 5.0m)
            ];

            ColoredText.WriteLine("Did not find a saved list to load. Created a sample list with some tasks\n", ConsoleColor.Yellow);
            return Products;
        }
    }
}
