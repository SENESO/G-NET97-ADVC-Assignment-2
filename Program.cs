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
            // Load shared starter product catalog
            List<Product> catalog = ProductCatalog.GetCatalog();

            #region Question 01 / Task 01: Smart Product Search
            /*
             * =========================================================================
             * Task 01: Smart Product Search
             * =========================================================================
             * Requirement:
             * Write a single method called SearchProducts that accepts:
             *   1. The product list (List<Product>)
             *   2. A delegate representing the filter condition (Func<Product, bool>)
             * The method returns a List containing only the products that satisfy the condition.
             * Call this method 4 times using lambda expressions:
             *   1. All Electronics products
             *   2. Products cheaper than $50
             *   3. Products that are in stock (Stock > 0)
             *   4. Clothing products under $100
             * 
             * Delegate Used:
             *   Func<Product, bool> (and custom delegate ProductFilter)
             * Why:
             *   Func<T, bool> encapsulates a method that takes a single Product parameter
             *   and returns a boolean indicating whether the product satisfies the filter condition.
             *   This adheres to the Open-Closed Principle (OCP): the search engine is open
             *   for extension with any future search criteria, but closed for modification.
             * =========================================================================
             */

            // 1. All Electronics products
            Helper.PrintHeader("Electronics");
            List<Product> electronics = ProductSearchEngine.SearchProducts(catalog, p => p.Category == "Electronics");
            Helper.PrintProducts(electronics);

            // 2. Products cheaper than $50
            Helper.PrintHeader("Under $50");
            List<Product> cheapProducts = ProductSearchEngine.SearchProducts(catalog, p => p.Price < 50);
            Helper.PrintProducts(cheapProducts);

            // 3. Products that are in stock (Stock > 0)
            Helper.PrintHeader("In Stock");
            List<Product> inStockProducts = ProductSearchEngine.SearchProducts(catalog, p => p.Stock > 0);
            Helper.PrintProducts(inStockProducts);

            // 4. Clothing products under $100
            Helper.PrintHeader("Clothing Under $100");
            List<Product> affordableClothing = ProductSearchEngine.SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            Helper.PrintProducts(affordableClothing);

            #endregion

            #region Question 02 / Task 03.1: Custom Report Generator - Print Reports
            /*
             * =========================================================================
             * Task 03.1: Print Reports
             * =========================================================================
             * Requirement:
             * Write a method called PrintReport that accepts the product list and an Action.
             * The method loops through all products and calls the action on each one.
             * The caller decides what to print by passing a lambda.
             *   Scenario 1 Short Report: Print each product as Name - $Price
             *   Scenario 2 Detailed Report: Print each product as [Category] Name | Price: $X | Stock: Y
             * 
             * Delegate Used:
             *   Action<Product>
             * Why:
             *   Action<T> represents a delegate that takes an input of type T and returns void.
             *   It is specifically intended for executing side-effects (such as printing to console,
             *   logging, or rendering) without requiring any return value from the function.
             * =========================================================================
             */

            // Scenario 1: Short Report
            Helper.PrintHeader("Short Report");
            ReportEngine.PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));
            Console.WriteLine();

            // Scenario 2: Detailed Report
            Helper.PrintHeader("Detailed Report");
            ReportEngine.PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
            Console.WriteLine();

            #endregion

            #region Question 03 / Task 03.2: Custom Report Generator - Transform Products
            /*
             * =========================================================================
             * Task 03.2: Transform Products
             * =========================================================================
             * Requirement:
             * Write a method called TransformProducts that accepts the product list and a Func.
             * The method returns a List by applying the function to each product.
             *   Scenario 3 Summary List: Transform each product into a string like "Laptop ($1200)". Print all results.
             *   Scenario 4 Price Label: Transform each product into "Expensive!" if Price > $100, or "Affordable" otherwise.
             *                           Print each as Name: Label.
             * 
             * Delegate Used:
             *   Func<Product, TResult> (in these scenarios, Func<Product, string>)
             * Why:
             *   Func<T, TResult> takes an input of type T and returns a value of type TResult.
             *   It is the standard, strongly-typed delegate for mapping/projection operations,
             *   allowing us to convert a Product into a formatted summary string or a classified label.
             * =========================================================================
             */

            // Scenario 3: Summary List
            Helper.PrintHeader("Summary List");
            List<string> summaries = ReportEngine.TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            Helper.PrintList(summaries);

            // Scenario 4: Price Labels
            Helper.PrintHeader("Price Labels");
            List<string> priceLabels = ReportEngine.TransformProducts(catalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
            Helper.PrintList(priceLabels);

            #endregion

            #region Question 04 / Task 03.3: Custom Report Generator - Filter Products
            /*
             * =========================================================================
             * Task 03.3: Filter Products
             * =========================================================================
             * Requirement:
             * Write a method called FilterProducts that accepts the product list and a Predicate.
             * The method returns a List of products that match the condition.
             *   Scenario 5 Low-Stock Alert: Find products with Stock < 20 and print an alert for each
             *                               in the format: [LOW STOCK] Name: only X left!
             * 
             * Delegate Used:
             *   Predicate<Product>
             * Why:
             *   Predicate<T> is a specialized built-in delegate that accepts an object of type T
             *   and returns a boolean value (equivalent to Func<T, bool>). It explicitly communicates
             *   intent for condition checks and criteria filtering in collections (e.g. List.FindAll).
             * =========================================================================
             */

            // Scenario 5: Low-Stock Alert
            Helper.PrintHeader("Low-Stock Alert");
            List<Product> lowStockProducts = ReportEngine.FilterProducts(catalog, p => p.Stock < 20);
            foreach (var p in lowStockProducts)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }
            Console.WriteLine();

            #endregion
        }
    }
}
