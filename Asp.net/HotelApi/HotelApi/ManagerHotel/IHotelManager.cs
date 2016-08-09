using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HotelApi_.Models;

namespace HotelApi_.ManagerHotel
{
    public interface IHotelManager
    {
        bool Add(Hotel hotel);

        bool Update(Hotel hotel);

        IEnumerable<Hotel> GetHotelsByCity(string city);

        IEnumerable<Hotel> GetHotesByRooms(int minRooms, int maxRooms);

        IEnumerable<Hotel> GetHotelByRating(int minRating, int maxRating);

        IEnumerable<Hotel> GetHotelSearchByName(string searchText);

        IEnumerable<Hotel> GetHotelsPageOf(int page, int itemsPerPage, IEnumerable<Hotel> listHotels);

        IEnumerable<Hotel> GetHotelsPage(int page, int itemsPerPage);

        uint GetValidId();

        bool Delete(uint id);

        HotelManager GetInstance();

        IEnumerable<string> GetListOfDistinctCity();

        HotelResponse FilterHotels(HotelRequest hotelRequest);

    }
}
