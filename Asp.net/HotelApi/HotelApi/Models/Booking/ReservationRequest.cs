using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApi_.Models.Booking
{
    public class ReservationRequest
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}