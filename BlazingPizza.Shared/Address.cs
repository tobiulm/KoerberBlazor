using System.ComponentModel.DataAnnotations;

namespace BlazingPizza
{
    /// <summary>
    /// Represents an address associated with a user.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the unique identifier for the address.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the address.
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the street name of the address.
        /// </summary>
        [Required, MaxLength(100)]
        public string Street { get; set; }
       
        /// <summary>
        /// Gets or sets the city of the address.
        /// </summary>
        [Required, MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the address.
        /// </summary>
        [Required, MaxLength(5)]        
        public string PostalCode { get; set; }
        
        /// <summary>
        /// Gets or sets the user ID associated with the address.
        /// </summary>
        public string UserId { get; set; }
    }
}