using Assignment02.Models;

namespace Assignment02.Search
{
    /// <summary>
    /// Custom delegate definition representing a filter condition on a Product.
    /// Used to illustrate custom delegates vs built-in delegates.
    /// </summary>
    public delegate bool ProductFilter(Product product);

    /// <summary>
    /// Implements flexible product search logic for Task 01.
    /// Allows filtering products dynamically without modifying the underlying search method (Open-Closed Principle).
    /// </summary>
    public static class ProductSearchEngine
    {
        /// <summary>
        /// Task 01: Searches products based on a specified filter condition using Func&lt;Product, bool&gt;.
        /// Delegate Used: Func&lt;Product, bool&gt;
        /// Why: Func is a built-in generic delegate that takes a Product as an input parameter
        /// and returns a boolean value indicating whether the product meets the search criteria.
        /// </summary>
        /// <param name="products">The product list to search from.</param>
        /// <param name="filter">The delegate filter condition.</param>
        /// <returns>A new List of products matching the condition.</returns>
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new();
            foreach (var product in products)
            {
                if (filter(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }

        /// <summary>
        /// Demonstrates filtering using a user-defined custom delegate (ProductFilter).
        /// </summary>
        public static List<Product> SearchProductsWithCustomDelegate(List<Product> products, ProductFilter filter)
        {
            List<Product> result = new();
            foreach (var product in products)
            {
                if (filter(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }
    }
}
