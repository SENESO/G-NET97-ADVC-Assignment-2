using Assignment02.Models;

namespace Assignment02.Common
{
   
    public static class Helper
    {
        public static void PrintHeader(string title)
        {
            Console.WriteLine($"--- {title} ---");
        }

        public static void PrintProducts(List<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }
            Console.WriteLine();
        }

        public static void PrintList<T>(List<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
