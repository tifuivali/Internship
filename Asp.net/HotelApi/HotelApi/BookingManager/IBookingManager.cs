using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApi_.Models.Booking;

namespace HotelApi_.BookingManager
{
    public interface IBookingManager
    {
        bool Add(Reservation reservation);

        ReservationResponse GetReservations(ReservationRequest request);

        bool Update(Reservation reservation);


    }
}