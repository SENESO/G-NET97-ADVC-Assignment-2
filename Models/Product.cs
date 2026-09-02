namespace Assignment02.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"{Name} - ${Price} (Stock: {Stock})";
        }
    }
}
