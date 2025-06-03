namespace BlazingPizza
{
    /// <summary>
    /// Represents a topping that can be added to a pizza.
    /// </summary>
    public class Topping
    {
        /// <summary>
        /// Gets or sets the unique identifier for the topping.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the topping.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the topping.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Formats the price of the topping as a string.
        /// </summary>
        /// <returns>The formatted price as a string.</returns>
        public string GetFormattedPrice() => Price.ToString("0.00");
    }
}