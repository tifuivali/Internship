using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApi_.ManagerHotel;
using HotelApi_.Models;
using HotelApi_.Models.Booking;
using HotelApi_.Service;

namespace HotelApi_.Controllers
{
    public class HotelsController : ApiController
    {

        //   private IHotelManager hotelManager = HotelManagerHibernate.GetInstance();
        private IHotelManager hotelManager =(IHotelManager) ServiceLocator.GetService(typeof(IHotelManager));


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
        /// <param name="hotelModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Hotels/Add")]
        public HttpResponseMessage Add([FromBody] HotelModel hotelModel)
        {
            if(hotelModel.Name.Length>50)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel name length too large!");
            if(hotelModel.Description.Length>500)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel description length too large!");
            if(hotelModel.Rating == 6)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Value for rating is not valid!");
            if (!hotelManager.Add(hotelModel))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel with the same id already exists!");
            return Request.CreateResponse(HttpStatusCode.OK, "Succes");
        }

        /// <summary>
        /// Update hotel action.
        /// </summary>
        /// <param name="hotelModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Hotels/Update")]
        public HttpResponseMessage Update([FromBody] HotelModel hotelModel)
        {
            if (hotelModel.Name.Length > 50)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel name length too large!");
            if (hotelModel.Description.Length > 500)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel description length too large!");
            if (hotelModel.Rating == 6)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Value for rating is not valid!");
            if (!hotelManager.Add(hotelModel))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel with the same id already exists!");
            if (!hotelManager.Update(hotelModel))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel doesn't exists!");
            return Request.CreateResponse(HttpStatusCode.OK, "Succes");
        }

        /// <summary>
        /// Return a valid id.
        /// </summary>
        /// <returns></returns>
        [Route("api/Hotels/GetValidId")]
        public int GetValidId()
        {
            return hotelManager.GetValidId();
        }

        /// <summary>
        /// Delete bspecified hotel from request.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Hotels/Delete")]
        public HttpResponseMessage Delete(int id)
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