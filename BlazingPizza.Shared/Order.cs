using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace BlazingPizza
{
    /// <summary>
    /// Represents an order placed by a user.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the order.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the order was created.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the delivery address for the order.
        /// </summary>
        [ValidateComplexType()]
        public Address DeliveryAddress { get; set; } = new Address();

        /// <summary>
        /// Gets or sets the geographical location for the delivery.
        /// </summary>
        public LatLong DeliveryLocation { get; set; }

        /// <summary>
        /// Gets or sets the list of pizzas included in the order.
        /// </summary>
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        /// <summary>
        /// Calculates the total price of the order.
        /// </summary>
        /// <returns>The total price of the order as a decimal.</returns>
        public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());

        /// <summary>
        /// Formats the total price of the order as a string.
        /// </summary>
        /// <returns>The formatted total price as a string.</returns>
        public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
    }
}