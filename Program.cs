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

            #region Question 01: Smart Product Search
            /*
             * Question 01:
             * Write a method called SearchProducts that accepts:
             *   1. The product list (List<Product>)
             *   2. A delegate for the filter condition (Func<Product, bool>)
             * The method returns a list of products matching the condition.
             * Call it 4 times with lambdas:
             *   - All Electronics products
             *   - Products cheaper than $50
             *   - Products in stock (Stock > 0)
             *   - Clothing products under $100
             * 
             * Answer & Explanation:
             * - Delegate used: Func<Product, bool>
             * - Why: We need to evaluate each product and decide whether to include it or not.
             *   Func<Product, bool> takes a Product as an input parameter and returns a boolean (true/false).
             *   This makes the search flexible because the caller can pass any filter condition
             *   using a lambda without changing the SearchProducts method itself.
             */

            // 1. All Electronics products
            Helper.PrintHeader("Electronics");
            List<Product> electronics = ProductSearchEngine.SearchProducts(catalog, p => p.Category == "Electronics");
            Helper.PrintProducts(electronics);

            // 2. Products cheaper than $50
            Helper.PrintHeader("Under $50");
            List<Product> cheapProducts = ProductSearchEngine.SearchProducts(catalog, p => p.Price < 50);
            Helper.PrintProducts(cheapProducts);

            // 3. Products in stock (Stock > 0)
            Helper.PrintHeader("In Stock");
            List<Product> inStockProducts = ProductSearchEngine.SearchProducts(catalog, p => p.Stock > 0);
            Helper.PrintProducts(inStockProducts);

            // 4. Clothing products under $100
            Helper.PrintHeader("Clothing Under $100");
            List<Product> affordableClothing = ProductSearchEngine.SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            Helper.PrintProducts(affordableClothing);

            #endregion

            #region Question 02: Custom Report Generator - Print Reports (Task 3.1)
            /*
             * Question 02:
             * Write a method called PrintReport that accepts the product list and an Action delegate.
             * It loops through the products and calls the action on each one.
             * Call it for two scenarios:
             *   Scenario 1 (Short Report): Name - $Price
             *   Scenario 2 (Detailed Report): [Category] Name | Price: $X | Stock: Y
             * 
             * Answer & Explanation:
             * - Delegate used: Action<Product>
             * - Why: We just want to perform a printing action on each product and we don't need
             *   to return any value. Action<T> is designed for methods that return void.
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

            #region Question 03: Custom Report Generator - Transform Products (Task 3.2)
            /*
             * Question 03:
             * Write a method called TransformProducts that accepts the product list and a Func delegate.
             * It returns a new list by applying the function to each product.
             * Call it for two scenarios:
             *   Scenario 3 (Summary List): string like "Laptop ($1200)"
             *   Scenario 4 (Price Labels): "Expensive!" if Price > 100, else "Affordable", printed as Name: Label
             * 
             * Answer & Explanation:
             * - Delegate used: Func<Product, string> (or generic Func<Product, TResult>)
             * - Why: We need to take a Product and transform/map it into a new value (here, a formatted string).
             *   Func<T, TResult> takes an input and returns an output, which fits data transformation.
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

            #region Question 04: Custom Report Generator - Filter Products (Task 3.3)
            /*
             * Question 04:
             * Write a method called FilterProducts that accepts the product list and a Predicate delegate.
             * It returns a list of products that match the condition.
             * Call it for:
             *   Scenario 5 (Low-Stock Alert): products with Stock < 20, format: [LOW STOCK] Name: only X left!
             * 
             * Answer & Explanation:
             * - Delegate used: Predicate<Product>
             * - Why: Predicate<T> takes an object and returns a bool. It is the built-in C# delegate
             *   specifically meant for condition checking and filtering (like List.FindAll).
             */

            // Scenario 5: Low-Stock Alert
            Helper.PrintHeader("Low-Stock Alert");
            List<Product> lowStock = ReportEngine.FilterProducts(catalog, p => p.Stock < 20);
            foreach (var p in lowStock)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }
            Console.WriteLine();

            #endregion

            #region Bonus: Delegate Evolution (Custom Delegate, Anonymous Method, Lambda)
            /*
             * Bonus Demo (Matching Session Demo concepts):
             * Demonstrates the three ways to pass logic to a delegate in C#:
             *   1. User-defined custom delegate vs built-in Func
             *   2. Anonymous method (C# 2.0 syntax)
             *   3. Lambda expression (C# 3.0+ syntax)
             */

            // 1. Using user-defined custom delegate (ProductFilter)
            ProductFilter customFilter = delegate (Product p) { return p.Category == "Books"; };
            List<Product> booksWithAnon = ProductSearchEngine.SearchProductsWithCustomDelegate(catalog, customFilter);

            // 2. Using same filter with lambda
            List<Product> booksWithLambda = ProductSearchEngine.SearchProducts(catalog, p => p.Category == "Books");

            #endregion
        }
    }
}
