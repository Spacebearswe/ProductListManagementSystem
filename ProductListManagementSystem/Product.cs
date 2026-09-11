using System;
using System.Collections.Generic;
using System.Text;

namespace ProductListManagementSystem
{
    public class Product
    {
        private static int _nextId = 1; // starts at 1
        ///// <summary>
        ///// Gets or sets the product ID.
        ///// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public string Category  { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        
        //public string Description { get; set; }
        ///// <summary>
        ///// Gets or sets the price.
        ///// </summary>
        public decimal Price { get; set; }

        public Product(string name, string category, decimal price)
        {
            Id = _nextId++;
            Category = category;
            Name = name;
            Price = price;
        }




    }
}
