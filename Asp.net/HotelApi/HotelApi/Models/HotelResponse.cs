using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApi_.Models
{
    public class HotelResponse
    {
        public IEnumerable<Hotel> Hotels { get; set; }

        public int TotalItems { get; set; }
    }
}