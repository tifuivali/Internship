﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApi_.ManagerHotel;
using HotelApi_.Models;
using HotelApi_.Models.Booking;
using HotelApi_.Models.Filter;
using Newtonsoft.Json;

namespace HotelApi_.Controllers
{
    public class HotelsController : ApiController
    {

        HotelManager hotelManager = HotelManager.GetInstance();
       


        /// <summary>
        /// Get All Products by request
        /// </summary>
        /// <returns></returns>
        [Route("api/Hotels/GetHotels")]
        public HotelResponse GetHotels([FromUri] HotelRequest hotelRequest)
        {
            return hotelManager.FilterHotels(hotelRequest);
        }



        /// <summary>
        /// Add hotel action
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Hotels/Add")]
        public HttpResponseMessage Add([FromBody] Hotel hotel)
        {
            if (!hotelManager.Add(hotel))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel with the same id already exists!");
            return Request.CreateResponse(HttpStatusCode.OK, "Succes");
        }

        /// <summary>
        /// Update hotel action.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Hotels/Update")]
        public HttpResponseMessage Update([FromBody] Hotel hotel)
        {
            if (!hotelManager.Update(hotel))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel doesn't exists!");
            return Request.CreateResponse(HttpStatusCode.OK, "Succes");
        }

        /// <summary>
        /// Return a valid id.
        /// </summary>
        /// <returns></returns>
        [Route("api/Hotels/GetValidId")]
        public uint GetValidId()
        {
            return hotelManager.GetValidId();
        }

        /// <summary>
        /// Delete bspecified hotel from request.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Hotels/Delete")]
        public HttpResponseMessage Delete(uint id)
        {
            if (!hotelManager.Delete(id))
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not fund hotel with id:" + id);
            return Request.CreateResponse(HttpStatusCode.OK, "Success!");
        }

        /// <summary>
        /// Get distinct list of cities.
        /// </summary>
        /// <returns></returns>
        [Route("api/Hotels/GetListOfCity")]
        public IEnumerable<string> GetListOfCity()
        {
            return hotelManager.GetListOfDistinctCity();
        }

        

    
        
    }

}