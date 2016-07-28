using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApi_.Models
{
    public class HotelRequest
    {
        public string Name { get; set; }

        public string City { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int MinRoomsCount { get; set; }

        public int MaxRoomsCount { get; set; }

        public int MinRating { get; set; }

        public int MaxRating { get; set; }
    }
}