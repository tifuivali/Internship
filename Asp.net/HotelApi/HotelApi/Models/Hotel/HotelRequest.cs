namespace HotelApi_.Models
{
    /// <summary>
    /// Hotel Request
    /// </summary>
    public class HotelRequest
    {
        /// <summary>
        /// Name of Hotel.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Number of page to return.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Number of elements per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Number of min rooms.
        /// </summary>
        public int MinRoomsCount { get; set; }

        /// <summary>
        /// Number of max rooms.
        /// </summary>
        public int MaxRoomsCount { get; set; }

        /// <summary>
        /// Number of min stars.
        /// </summary>
        public int MinRating { get; set; }

        /// <summary>
        /// Number of max stars.
        /// </summary>
        public int MaxRating { get; set; }

        public string Filter { get; set; }
    }
}