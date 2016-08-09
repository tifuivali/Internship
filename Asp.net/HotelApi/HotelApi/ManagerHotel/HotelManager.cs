using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi_.Models;

namespace HotelApi_.ManagerHotel
{
    public abstract class HotelManager:IHotelManager
    {
        public abstract bool Add(Hotel hotel);
        public abstract bool Update(Hotel hotel);

        public int Count { get; set; }

        public abstract IEnumerable<Hotel> GetHotelsByCity(string city);


        public abstract IEnumerable<Hotel> GetHotesByRooms(int minRooms, int maxRooms);


        public abstract IEnumerable<Hotel> GetHotelByRating(int minRating, int maxRating);

        public abstract IEnumerable<Hotel> GetHotelSearchByName(string searchText);

        public IEnumerable<Hotel> GetHotelsPageOf(int page, int itemsPerPage, IEnumerable<Hotel> listHotels)
        {
            int startIndex = itemsPerPage * (page - 1);
            return listHotels.Skip(startIndex).Take(itemsPerPage);
        }

        public abstract IEnumerable<Hotel> GetHotelsPage(int page, int itemsPerPage);

        public abstract uint GetValidId();

        public abstract bool Delete(uint id);

        public abstract HotelManager GetInstance();

        public abstract IEnumerable<string> GetListOfDistinctCity();

        public abstract HotelResponse FilterHotels(HotelRequest hotelRequest);
    }
}
