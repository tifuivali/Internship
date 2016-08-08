using System.Collections.Generic;

namespace HotelApi_.Models
{
    /// <summary>
    /// Hotel Response 
    /// </summary>
    public class HotelResponse
    {
        /// <summary>
        /// List of Hotels.
        /// </summary>
        public IEnumerable<Hotel> Hotels { get; set; }

        /// <summary>
        /// Get Total Items.
        /// </summary>
        public int TotalItems { get; set; }

        public Filter.Filter Filter { get; set; }
    }
}