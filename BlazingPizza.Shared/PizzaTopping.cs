namespace BlazingPizza
{
    /// <summary>
    /// Represents a topping added to a pizza.
    /// </summary>
    public class PizzaTopping
    {
        /// <summary>
        /// Gets or sets the topping associated with the pizza.
        /// </summary>
        public Topping Topping { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the topping.
        /// </summary>
        public int ToppingId { get; set; }
        
        /// <summary>
        /// Gets or sets the unique identifier for the pizza the topping is associated with.
        /// </summary>
        public int PizzaId { get; set; }
    }
}