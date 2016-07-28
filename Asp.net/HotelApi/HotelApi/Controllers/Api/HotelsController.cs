using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApi_.ManagerHotel;
using HotelApi_.Models;

namespace HotelApi_.Controllers
{
    public class HotelsController : ApiController
    {

        HotelManager hotelManager = HotelManager.GetInstance();



        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        [Route("api/Hotels/GetHotels")]
        public HotelResponse GetHotels([FromUri] HotelRequest hotelRequest)
        {
            if (hotelRequest == null)
                return new HotelResponse()
                {
                    Hotels = hotelManager.GetHotelsPage(1, 10),
                    TotalItems = hotelManager.Count
                };
            IEnumerable<Hotel> hotelFiltred = hotelManager.GetHotelSearchByName(hotelRequest.Name)
                .Intersect(hotelManager.GetHotelByRating(hotelRequest.MinRating, hotelRequest.MaxRating))
                .Intersect(hotelManager.GetHotelsByCity(hotelRequest.City))
                .Intersect(hotelManager.GetHotesByRooms(hotelRequest.MinRoomsCount, hotelRequest.MaxRoomsCount));
            return new HotelResponse()
            {
                Hotels = hotelManager.GetHotelsPageOf(hotelRequest.Page,hotelRequest.PageSize,hotelFiltred),
                TotalItems = hotelFiltred.Count()
            };

        }
        



        [HttpPost]
        [Route("api/Hotels/Add")]
        public HttpResponseMessage Add([FromBody] Hotel hotel)
        {
            if(!hotelManager.Add(hotel))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel with the same id already exists!");
            return Request.CreateResponse(HttpStatusCode.OK, "Succes");
        }
       
        [HttpGet]
        [Route("api/Hotels/GetNumberItems")]
        public int GetNumberItems()
        {
            return hotelManager.Count;
        }

        [HttpPost]
        [Route("api/Hotels/Update")]
        public HttpResponseMessage Update([FromBody] Hotel hotel)
        {
            if (!hotelManager.Update(hotel))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel doesn't exists!");
            return Request.CreateResponse(HttpStatusCode.OK, "Succes");
        }
     

        [Route("api/Hotels/GetValidId")]
        public uint GetValidId()
        {
            return hotelManager.GetValidId();
        }

        [Route("api/Hotels/Delete")]
        public HttpResponseMessage Delete(uint id)
        {
            if(!hotelManager.Delete(id))
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not fund hotel with id:" + id);
            return Request.CreateResponse(HttpStatusCode.OK, "Success!");
        }

        [Route("api/Hotels/GetHotelById")]
        public Hotel GetHotelById(int id)
        {
            if (hotelManager.Hotels.Count <= 0)
                 hotelManager.PopulateHotels();
            return hotelManager.Hotels.First(h => h.Id == id);

        }

    }

}