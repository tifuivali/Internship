using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HotelApi_.Models;

namespace HotelApi_.Controllers
{
    public class HotelsController : ApiController
    {

        List<Hotel> hotels = new List<Hotel>();

        private void PopulateHotels()
        {
            hotels.Add(new Hotel()
            {
                Id = 1,
                Name = "Hotel Victoria",
                City = "Bucuresti",
                Description = "Un hotel ok",
                Rating = 3,
                RoomsCount = 60
            });

            hotels.Add(new Hotel()
            {
                Id = 2,
                City = "Iasi",
                Description = "Plasat in centrul orasului",
                Name = "Hotel Traian",
                Rating = 5,
                RoomsCount = 200
            });

            hotels.Add(new Hotel()
            {
                Id = 3,
                City = "Cluj Napoca",
                Description = "Fara",
                Name = "Hotel Europa",
                Rating = 4,
                RoomsCount = 140
            });
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Hotel> GetAllHotels()
        {
            if (hotels.Count > 0)
            {
                return hotels;
            }
            PopulateHotels();
            return hotels;
        }

        public IEnumerable<Hotel> GetHotelByName(string name)
        {
            if (hotels.Count > 0)
            {
                return hotels.Where(h => h.Name == name);
            }
            PopulateHotels();
            return hotels.Where(h => h.Name == name);

        }

        [Route("api/Hotels/GetHotelById")]
        public Hotel GetHotelById(int id)
        {
            if (hotels.Count <= 0)
                 PopulateHotels();
            return hotels.First(h => h.Id == id);

        }

    }

}