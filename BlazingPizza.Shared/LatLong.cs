namespace BlazingPizza
{
    /// <summary>
    /// Represents a geographical location with latitude and longitude coordinates.
    /// </summary>
    public class LatLong
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LatLong"/> class.
        /// This constructor is private and used internally.
        /// </summary>
        private LatLong()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LatLong"/> class with specified latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude of the location.</param>
        /// <param name="longitude">The longitude of the location.</param>
        public LatLong(double latitude, double longitude) : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Gets or sets the latitude of the location.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the location.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Interpolates between two geographical locations based on a proportion.
        /// </summary>
        /// <param name="start">The starting location.</param>
        /// <param name="end">The ending location.</param>
        /// <param name="proportion">
        /// The proportion of the interpolation, where 0 represents the start and 1 represents the end.
        /// </param>
        /// <returns>A new <see cref="LatLong"/> instance representing the interpolated location.</returns>
        public static LatLong Interpolate(LatLong start, LatLong end, double proportion)
        {
            // The Earth is flat, right? So no need for spherical interpolation.
            return new LatLong(
                start.Latitude + (end.Latitude - start.Latitude) * proportion,
                start.Longitude + (end.Longitude - start.Longitude) * proportion);
        }
    }
}