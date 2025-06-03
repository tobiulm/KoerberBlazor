namespace BlazingPizza
{
    /// <summary>
    /// Represents a pre-configured template for a pizza a user can order.
    /// </summary>
    public class PizzaSpecial
    {
        /// <summary>
        /// Gets or sets the unique identifier for the pizza special.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the pizza special.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the base price of the pizza special.
        /// </summary>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// Gets or sets the description of the pizza special.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the URL of the image representing the pizza special.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Formats the base price of the pizza special as a string.
        /// </summary>
        /// <returns>The formatted base price as a string.</returns>
        public string GetFormattedBasePrice() => BasePrice.ToString("0.00");
    }
}