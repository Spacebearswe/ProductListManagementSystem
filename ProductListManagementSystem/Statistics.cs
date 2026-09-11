
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ProductListManagementSystem.Interfaces;

namespace ProductListManagementSystem;

public class Statistics : IStatistics
{
    /// <summary>
    /// Gets the name of the product with the highest price.
    /// </summary>
    /// <param name="products">The list of products.</param>
    /// <returns>The name of the product with the highest price, or an empty string if the list is null or empty.</returns>
    public string GetHighestNumber(List<Product> products)
    {
        if (products == null || products.Count == 0) return "";

        var highest = products.OrderByDescending(p => p.Price).FirstOrDefault();
        if (highest == null) return "";
        else
            return highest.Name;
    }

    /// <summary>
    /// Gets the name of the product with the lowest price.
    /// </summary>
    /// <param name="products">The list of products.</param>
    /// <returns>The name of the product with the lowest price, or an empty string if the list is null or empty.</returns>
    public string GetLowestNumber(List<Product> products)
    {
        if (products == null || products.Count == 0) return "";

        var lowest = products.OrderBy(p => p.Price).FirstOrDefault();
        if (lowest == null) return "";
        else
            return lowest.Name;
    }

    /// <summary>
    /// Gets the total price of all products.
    /// </summary>
    /// <param name="products">The list of products.</param>
    /// <returns>The total price of all products, or "0.00" if the list is null or empty.</returns> 
    public string GetTotalPrice(List<Product> products)
    {
        if (products == null || products.Count == 0) return "0.00";
        return products.Sum(p => p.Price).ToString("F2");
    }
}

