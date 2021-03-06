﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApi_.Models.Booking;
using System.Web.Mvc;

namespace HotelApi_.BookingManager
{
    public class BookingManager:IBookingManager
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

        public bool Add(Reservation reservation)
        {
            books.Add(reservation);
            return true;
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

        public ReservationResponse GetReservations(ReservationRequest req)
        {
            var reservations = books.Skip(req.PageSize*(req.Page-1)).Take(req.PageSize);
            ReservationResponse response = new ReservationResponse()
            {
                Reservations = reservations,
                TotalItems = books.Count
            };

            return response;
        }

        public bool Update(Reservation reservation)
        {
            int index = -1;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Id == reservation.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index < 0)
                return false;
            books.RemoveAt(index);
            books.Insert(index,reservation);
            return true;
        }

    }
}