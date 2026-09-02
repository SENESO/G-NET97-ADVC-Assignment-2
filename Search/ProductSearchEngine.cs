using Assignment02.Models;

namespace Assignment02.Search
{
    // Custom delegate definition for filtering products
    public delegate bool ProductFilter(Product product);

    public static class ProductSearchEngine
    {
        // Task 01: Search using Func<Product, bool>
        // We pass the filter logic as a parameter so any condition can be used without modifying this code
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new();
            foreach (var product in products)
            {
                if (filter(product))
                    result.Add(product);
            }
            return result;
        }

        // Overload using custom delegate to demonstrate custom delegate vs built-in Func
        public static List<Product> SearchProductsWithCustomDelegate(List<Product> products, ProductFilter filter)
        {
            List<Product> result = new();
            foreach (var product in products)
            {
                if (filter(product))
                    result.Add(product);
            }
            return result;
        }
    }
}
