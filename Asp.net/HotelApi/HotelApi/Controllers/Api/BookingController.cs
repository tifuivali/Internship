using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApi_.Models.Booking;

namespace HotelApi_.Controllers.Api
{
    public class BookingController:ApiController
    {

        BookingManager.BookingManager bookingManager = BookingManager.BookingManager.GetInstance();

        [HttpGet]
        [Route("api/Booking/AllReservations")]
        public ReservationResponse AllReservations([FromUri]  ReservationRequest reservationRequest)
        {
         
            return bookingManager.GetReservations(reservationRequest);
        }

        [HttpPost]
        [Route("api/Booking/Reserve")]
        public HttpResponseMessage Reserve([FromBody] Reservation reservation )
        {
            bookingManager.Add(reservation);
            return Request.CreateResponse(HttpStatusCode.OK, "Booking was succesfuly!");
        }

        [HttpPost]
        [Route("api/Booking/Update")]
        public HttpResponseMessage Update([FromBody] Reservation reservation)
        {
            if(bookingManager.Update(reservation))
                return  Request.CreateResponse(HttpStatusCode.OK,"Updated!");

            return Request.CreateResponse(HttpStatusCode.NotFound, "Reservation with thios id not found!");
        }
    }
}