using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApi_.Models.Booking;

namespace HotelApi_.BookingManager
{
    public class BookingManagerNHibernate:IBookingManager
    {
        private static BookingManagerNHibernate bookingManager;

        public static BookingManagerNHibernate GetInstance()
        {
            if(bookingManager == null)
                bookingManager=new BookingManagerNHibernate();
            return bookingManager;
        }


        public bool Add(Reservation reservation)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction=session.BeginTransaction())
                {
                    
                }
            }
            return true;
        }

        public ReservationResponse GetReservations(ReservationRequest request)
        {
            throw new NotImplementedException();
        }

        public bool Update(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}