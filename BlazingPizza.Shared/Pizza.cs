using System.Collections.Generic;
using System.Linq;

namespace BlazingPizza
{
    /// <summary>
    /// Represents a customized pizza as part of an order.
    /// </summary>
    public class Pizza
    {
        /// <summary>
        /// The default size of the pizza in centimeters.
        /// </summary>
        public const int DefaultSize = 28;

        /// <summary>
        /// The minimum size of the pizza in centimeters.
        /// </summary>
        public const int MinimumSize = 21;

        /// <summary>
        /// The maximum size of the pizza in centimeters.
        /// </summary>
        public const int MaximumSize = 40;

        /// <summary>
        /// Gets or sets the unique identifier for the pizza.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the order ID associated with the pizza.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the special type of the pizza.
        /// </summary>
        public PizzaSpecial Special { get; set; }

        /// <summary>
        /// Gets or sets the ID of the special type of the pizza.
        /// </summary>
        public int SpecialId { get; set; }

        /// <summary>
        /// Gets or sets the size of the pizza in centimeters.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the list of toppings added to the pizza.
        /// </summary>
        public List<PizzaTopping> Toppings { get; set; }

        /// <summary>
        /// Calculates the base price of the pizza based on its size and special type.
        /// </summary>
        /// <returns>The base price of the pizza as a decimal.</returns>
        public decimal GetBasePrice()
        {
            return (Size / (decimal) DefaultSize) * Special.BasePrice;
        }

        /// <summary>
        /// Calculates the total price of the pizza, including the base price and the cost of toppings.
        /// </summary>
        /// <returns>The total price of the pizza as a decimal.</returns>
        public decimal GetTotalPrice()
        {
            return GetBasePrice() + Toppings.Sum(t => t.Topping.Price);
        }

        /// <summary>
        /// Formats the total price of the pizza as a string.
        /// </summary>
        /// <returns>The formatted total price as a string.</returns>
        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("0.00");
        }
    }
}