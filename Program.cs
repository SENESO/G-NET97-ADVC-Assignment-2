using System;
using System.Collections.Generic;
using Assignment02.Common;
using Assignment02.Data;
using Assignment02.Models;
using Assignment02.Reporting;
using Assignment02.Search;

namespace Assignment02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = ProductCatalog.GetCatalog();

            #region Question 01
            // Delegate: Func<Product, bool>
            // Why: Takes a Product and returns bool, allowing dynamic search filters via lambdas.

            Helper.PrintHeader("Electronics");
            List<Product> electronics = ProductSearch.SearchProducts(catalog, p => p.Category == "Electronics");
            Helper.PrintProducts(electronics);

            Helper.PrintHeader("Under $50");
            List<Product> cheapProducts = ProductSearch.SearchProducts(catalog, p => p.Price < 50);
            Helper.PrintProducts(cheapProducts);

            Helper.PrintHeader("In Stock");
            List<Product> inStockProducts = ProductSearch.SearchProducts(catalog, p => p.Stock > 0);
            Helper.PrintProducts(inStockProducts);

            Helper.PrintHeader("Clothing Under $100");
            List<Product> affordableClothing = ProductSearch.SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            Helper.PrintProducts(affordableClothing);
            #endregion

            #region Question 02
            // Delegate: Action<Product>
            // Why: Used to execute a void printing operation for each product.

            Helper.PrintHeader("Short Report");
            ReportGenerator.PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));
            Console.WriteLine();

            Helper.PrintHeader("Detailed Report");
            ReportGenerator.PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
            Console.WriteLine();
            #endregion

            #region Question 03
            // Delegate: Func<Product, string>
            // Why: Transforms each Product into a formatted string and returns the result.

            Helper.PrintHeader("Summary List");
            List<string> summaries = ReportGenerator.TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            Helper.PrintList(summaries);

            Helper.PrintHeader("Price Labels");
            List<string> priceLabels = ReportGenerator.TransformProducts(catalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
            Helper.PrintList(priceLabels);
            #endregion

            #region Question 04
            // Delegate: Predicate<Product>
            // Why: Evaluates a condition on a Product and returns true or false for filtering.

            Helper.PrintHeader("Low-Stock Alert");
            List<Product> lowStock = ReportGenerator.FilterProducts(catalog, p => p.Stock < 20);
            foreach (var p in lowStock)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }
            Console.WriteLine();
            #endregion
        }
    }
}
