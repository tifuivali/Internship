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
        public IEnumerable<Reservation> AllReservations()
        {
            return bookingManager.Books;
        }

        [HttpPost]
        [Route("api/Booking/Reserve")]
        public HttpResponseMessage Reserve([FromBody] Reservation reservation )
        {
            bookingManager.Add(reservation);
            return Request.CreateResponse(HttpStatusCode.OK, "Booking was succesfuly!");
        }
    }
}