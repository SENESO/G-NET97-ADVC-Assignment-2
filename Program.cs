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
            /*
             * Question 01:
             * Write a SearchProducts method that accepts a product list and a filter condition delegate.
             * Call it with lambda expressions for:
             *   1. Electronics products
             *   2. Products cheaper than $50
             *   3. In-stock products (Stock > 0)
             *   4. Clothing products under $100
             * 
             * Answer:
             * - Delegate: Func<Product, bool>
             * - Why: It accepts a Product and returns a bool. This allows passing any filter
             *   condition as a lambda expression without modifying the SearchProducts method.
             */

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
            /*
             * Question 02:
             * Write a PrintReport method that accepts a product list and an Action delegate to print
             * products based on a caller-defined format.
             * Call it for:
             *   - Short Report: Name - $Price
             *   - Detailed Report: [Category] Name | Price: $X | Stock: Y
             * 
             * Answer:
             * - Delegate: Action<Product>
             * - Why: Action<T> represents a method with a void return type, which is ideal
             *   for executing print operations on each product without returning any data.
             */

            Helper.PrintHeader("Short Report");
            ReportGenerator.PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));
            Console.WriteLine();

            Helper.PrintHeader("Detailed Report");
            ReportGenerator.PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
            Console.WriteLine();
            #endregion

            #region Question 03
            /*
             * Question 03:
             * Write a TransformProducts method that accepts a product list and a Func delegate to
             * transform each product into a new list.
             * Call it for:
             *   - Summary List: "Name ($Price)"
             *   - Price Labels: "Expensive!" if Price > 100 else "Affordable"
             * 
             * Answer:
             * - Delegate: Func<Product, string> (or Func<Product, TResult>)
             * - Why: Func<T, TResult> takes an input and returns a transformed output,
             *   making it suitable for projecting products into formatted strings.
             */

            Helper.PrintHeader("Summary List");
            List<string> summaries = ReportGenerator.TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            Helper.PrintList(summaries);

            Helper.PrintHeader("Price Labels");
            List<string> priceLabels = ReportGenerator.TransformProducts(catalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
            Helper.PrintList(priceLabels);
            #endregion

            #region Question 04
            /*
             * Question 04:
             * Write a FilterProducts method that accepts a product list and a Predicate delegate.
             * Call it for:
             *   - Low-Stock Alert: Find products with Stock < 20 and print "[LOW STOCK] Name: only X left!"
             * 
             * Answer:
             * - Delegate: Predicate<Product>
             * - Why: Predicate<T> takes a Product and returns a bool, which is specifically designed
             *   for condition-based filtering in collections.
             */

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
