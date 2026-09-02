namespace Assignment02.Models
{
    /// <summary>
    /// Represents a product entity in the ShopMaster catalog.
    /// Starter code provided in Assignment 02 Page 2.
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // "Electronics", "Clothing", "Food", "Books"
        public double Price { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"{Name} - ${Price} (Stock: {Stock})";
        }
    }
}
