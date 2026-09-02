using Assignment02.Models;

namespace Assignment02.Reporting
{
    public static class ReportGenerator
    {
        public static void PrintReport(List<Product> products, Action<Product> reportAction)
        {
            foreach (var product in products)
            {
                reportAction(product);
            }
        }

        public static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> transform)
        {
            List<TResult> result = new();
            foreach (var product in products)
            {
                result.Add(transform(product));
            }
            return result;
        }

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
