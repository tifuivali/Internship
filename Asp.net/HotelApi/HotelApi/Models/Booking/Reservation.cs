using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApi_.Models.Booking
{
    public class Reservation
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

    }
}