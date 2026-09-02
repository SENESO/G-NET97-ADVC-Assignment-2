using Assignment02.Models;

namespace Assignment02.Search
{
    public delegate bool ProductFilter(Product product);

    public static class ProductSearch
    {
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
