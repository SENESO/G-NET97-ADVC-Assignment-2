using Assignment02.Models;

namespace Assignment02.Reporting
{
    public static class ReportEngine
    {
        // 3.1 Print Reports
        // Uses Action<Product> because we just need to execute a void method (printing/formatting) for each product
        public static void PrintReport(List<Product> products, Action<Product> reportAction)
        {
            foreach (var product in products)
            {
                reportAction(product);
            }
        }

        // 3.2 Transform Products
        // Uses Func<Product, TResult> because we are mapping each Product to something else (e.g. string) and returning it
        public static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> transform)
        {
            List<TResult> result = new();
            foreach (var product in products)
            {
                result.Add(transform(product));
            }
            return result;
        }

        // 3.3 Filter Products
        // Uses Predicate<Product> because it's designed specifically for boolean condition checks on an object
        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> predicate)
        {
            List<Product> result = new();
            foreach (var product in products)
            {
                if (predicate(product))
                    result.Add(product);
            }
            return result;
        }
    }
}
