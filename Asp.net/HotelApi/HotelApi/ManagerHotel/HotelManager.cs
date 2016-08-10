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
        public abstract bool Add(HotelModel hotelModel);
        public abstract bool Update(HotelModel hotelModel);

        public int Count { get; set; }

        public abstract IEnumerable<HotelModel> GetHotelsByCity(string city);


        public abstract IEnumerable<HotelModel> GetHotesByRooms(int minRooms, int maxRooms);


        public abstract IEnumerable<HotelModel> GetHotelByRating(int minRating, int maxRating);

        public abstract IEnumerable<HotelModel> GetHotelSearchByName(string searchText);

        public virtual IEnumerable<HotelModel> GetHotelsPageOf(int page, int itemsPerPage, IEnumerable<HotelModel> listHotels)
        {
            int startIndex = itemsPerPage * (page - 1);
            return listHotels.Skip(startIndex).Take(itemsPerPage);
        }

        public abstract IEnumerable<HotelModel> GetHotelsPage(int page, int itemsPerPage);

        public abstract int GetValidId();

        public abstract bool Delete(int id);

        public abstract IEnumerable<string> GetListOfDistinctCity();

        public abstract HotelResponse FilterHotels(HotelRequest hotelRequest);
    }
}
