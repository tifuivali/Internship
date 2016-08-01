using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace HotelApi_.Models.Booking
{
    public class ReservationResponse
    {
        public IEnumerable<Reservation> Reservations { get; set; }

        public int TotalItems { get; set; }
    }
}