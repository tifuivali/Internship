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
        public IEnumerable<Hotel> GetAllHotels()
        {
            if (hotelManager.Hotels.Count > 0)
            {
                return hotelManager.Hotels;
            }
            hotelManager.PopulateHotels();
            return hotelManager.Hotels;
        }

        public IEnumerable<Hotel> GetHotelByName(string name)
        {
            if (hotelManager.Hotels.Count > 0)
            {
                return hotelManager.Hotels.Where(h => h.Name == name);
            }
            hotelManager.PopulateHotels();
            return hotelManager.Hotels.Where(h => h.Name == name);

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
        [HttpGet]
        [Route("api/Hotels/GetPage")]
        public IEnumerable<Hotel> GetPage(int page,int itemsPerPage,string searchText )
        {
            if(searchText == null)
             return hotelManager.GetHotelsOnPage(page, itemsPerPage);

            return hotelManager.GetHotelSearch(searchText, page, itemsPerPage);
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