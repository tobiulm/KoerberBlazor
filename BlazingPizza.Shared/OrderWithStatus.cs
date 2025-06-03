using BlazingPizza.ComponentsLibrary.Map;
using System;
using System.Collections.Generic;

namespace BlazingPizza
{
    /// <summary>
    /// Represents an order with its current status and associated map markers.
    /// </summary>
    public class OrderWithStatus
    {
        /// <summary>
        /// The duration required to prepare the order.
        /// </summary>
        public static readonly TimeSpan PreparationDuration = TimeSpan.FromSeconds(10);

        /// <summary>
        /// The duration required to deliver the order.
        /// </summary>
        public static readonly TimeSpan
            DeliveryDuration = TimeSpan.FromMinutes(1); // Unrealistic, but more interesting to watch

        /// <summary>
        /// Gets or sets the order associated with the status.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the current status text of the order.
        /// </summary>
        public string StatusText { get; set; }

        /// <summary>
        /// Gets a value indicating whether the order has been delivered.
        /// </summary>
        public bool IsDelivered => StatusText == "Delivered";

        /// <summary>
        /// Gets or sets the list of map markers associated with the order's status.
        /// </summary>
        public List<Marker> MapMarkers { get; set; }

        /// <summary>
        /// Creates an <see cref="OrderWithStatus"/> instance from an <see cref="Order"/> object.
        /// </summary>
        /// <param name="order">The order to create the status for.</param>
        /// <returns>An <see cref="OrderWithStatus"/> instance representing the order's status.</returns>
        public static OrderWithStatus FromOrder(Order order)
        {
            // To simulate a real backend process, we fake status updates based on the amount
            // of time since the order was placed
            string statusText;
            List<Marker> mapMarkers;
            var dispatchTime = order.CreatedTime.Add(PreparationDuration);

            if (DateTime.Now < dispatchTime)
            {
                statusText = "Preparing";
                mapMarkers = [ToMapMarker("You", order.DeliveryLocation, showPopup: true)];
            }
            else if (DateTime.Now < dispatchTime + DeliveryDuration)
            {
                statusText = "Out for delivery";

                var startPosition = ComputeStartPosition(order);
                var proportionOfDeliveryCompleted = Math.Min(1,
                    (DateTime.Now - dispatchTime).TotalMilliseconds / DeliveryDuration.TotalMilliseconds);
                var driverPosition =
                    LatLong.Interpolate(startPosition, order.DeliveryLocation, proportionOfDeliveryCompleted);
                mapMarkers =
                [
                    ToMapMarker("You", order.DeliveryLocation),
                    ToMapMarker("Driver", driverPosition, showPopup: true)
                ];
            }
            else
            {
                statusText = "Delivered";
                mapMarkers =
                [
                    ToMapMarker("Delivery location", order.DeliveryLocation, showPopup: true)
                ];
            }

            return new OrderWithStatus
            {
                Order = order,
                StatusText = statusText,
                MapMarkers = mapMarkers,
            };
        }

        /// <summary>
        /// Computes the starting position of the delivery driver based on the order.
        /// </summary>
        /// <param name="order">The order to compute the start position for.</param>
        /// <returns>A <see cref="LatLong"/> instance representing the starting position.</returns>
        private static LatLong ComputeStartPosition(Order order)
        {
            // Random but deterministic based on order ID
            var rng = new Random(order.OrderId);
            var distance = 0.01 + rng.NextDouble() * 0.02;
            var angle = rng.NextDouble() * Math.PI * 2;
            var offset = (distance * Math.Cos(angle), distance * Math.Sin(angle));
            return new LatLong(order.DeliveryLocation.Latitude + offset.Item1,
                order.DeliveryLocation.Longitude + offset.Item2);
        }

        /// <summary>
        /// Converts a description and coordinates into a map marker.
        /// </summary>
        /// <param name="description">The description of the marker.</param>
        /// <param name="coords">The geographical coordinates of the marker.</param>
        /// <param name="showPopup">Indicates whether the marker should display a popup.</param>
        /// <returns>A <see cref="Marker"/> instance representing the map marker.</returns>
        static Marker ToMapMarker(string description, LatLong coords, bool showPopup = false)
            => new Marker {Description = description, X = coords.Longitude, Y = coords.Latitude, ShowPopup = showPopup};
    }
}