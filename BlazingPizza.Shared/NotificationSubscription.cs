namespace BlazingPizza
{
    /// <summary>
    /// Represents a subscription for receiving notifications.
    /// </summary>
    public class NotificationSubscription
    {
        /// <summary>
        /// Gets or sets the unique identifier for the notification subscription.
        /// </summary>
        public int NotificationSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the subscription.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the URL for the notification subscription.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the P256dh key used for encryption in the subscription.
        /// </summary>
        public string P256dh { get; set; }

        /// <summary>
        /// Gets or sets the authentication secret for the subscription.
        /// </summary>
        public string Auth { get; set; }
    }
}