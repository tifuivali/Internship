using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApi_.Models.Booking;
using System.Web.Mvc;

namespace HotelApi_.BookingManager
{
    public class BookingManager
    {
        private static BookingManager bookingManager;

        private List<Reservation> books;

        public List<Reservation> Books
        {
            get { return books.ToList(); }
        }
        private BookingManager()
        {
            books = new List<Reservation>();
        }

        public static BookingManager GetInstance()
        {
            return bookingManager ?? (bookingManager = new BookingManager());
        }

        public void Add(Reservation reservation)
        {
            books.Add(reservation);
        }

        public void Add(FormCollection collection)
        {
            var city = collection["city"];
            var name = collection["name"];
            var email = collection["email"];
            var phone = collection["phone"];
            var checkin = collection["checkin"];
            var checkout = collection["checkout"];
            var book = new Reservation()
            {
                CheckIn = DateTime.Parse(checkin),
                CheckOut = DateTime.Parse(checkout),
                Name = name,
                Email = email,
                City = city,
                Phone = phone
            };
            Add(book);
        }

    }
}