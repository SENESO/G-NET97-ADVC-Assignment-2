using Assignment02.Models;

namespace Assignment02.Reporting
{
    /// <summary>
    /// Custom Report Engine implementing Task 03 requirements.
    /// Demonstrates the use of built-in delegates: Action, Func, and Predicate.
    /// </summary>
    public static class ReportEngine
    {
        #region 3.1 Print Reports (Action<Product>)
        /// <summary>
        /// Task 3.1: Executes a custom print or formatting action for each product.
        /// Delegate Used: Action&lt;Product&gt;
        /// Why: Action&lt;T&gt; is a built-in delegate that encapsulates a method taking a parameter of type T
        /// and returning void. It is ideal for side-effect operations like printing, logging, or displaying
        /// data where no computed return value is needed.
        /// </summary>
        /// <param name="products">The list of products.</param>
        /// <param name="reportAction">Action to execute for each product.</param>
        public static void PrintReport(List<Product> products, Action<Product> reportAction)
        {
            foreach (var product in products)
            {
                reportAction(product);
            }
        }
        #endregion

        #region 3.2 Transform Products (Func<Product, TResult>)
        /// <summary>
        /// Task 3.2: Transforms each product into another type or formatted representation.
        /// Delegate Used: Func&lt;Product, TResult&gt;
        /// Why: Func&lt;T, TResult&gt; is a built-in delegate that encapsulates a method taking an input of type T
        /// and returning a result of type TResult. It is the perfect choice for mapping/transforming
        /// objects into new forms (such as strings, projection models, or calculated values).
        /// </summary>
        /// <typeparam name="TResult">The target projection type.</typeparam>
        /// <param name="products">The list of products.</param>
        /// <param name="transform">Transformation function.</param>
        /// <returns>A new list containing the transformed elements.</returns>
        public static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> transform)
        {
            List<TResult> result = new();
            foreach (var product in products)
            {
                result.Add(transform(product));
            }
            return result;
        }
        #endregion

        #region 3.3 Filter Products (Predicate<Product>)
        /// <summary>
        /// Task 3.3: Filters products matching a boolean evaluation criteria.
        /// Delegate Used: Predicate&lt;Product&gt;
        /// Why: Predicate&lt;T&gt; is a built-in delegate that represents a method taking an object of type T
        /// and returning a bool (equivalent to Func&lt;T, bool&gt;). It is explicitly designed for condition-based
        /// testing and filtering elements in a collection.
        /// </summary>
        /// <param name="products">The list of products.</param>
        /// <param name="predicate">The criteria delegate returning true if product matches.</param>
        /// <returns>A new list of products meeting the criteria.</returns>
        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> predicate)
        {
            List<Product> result = new();
            foreach (var product in products)
            {
                if (predicate(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }
        #endregion
    }
}
