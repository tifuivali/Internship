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
        bool Add(HotelModel hotelModel);

        bool Update(HotelModel hotelModel);

        IEnumerable<HotelModel> GetHotelsByCity(string city);

        IEnumerable<HotelModel> GetHotesByRooms(int minRooms, int maxRooms);

        IEnumerable<HotelModel> GetHotelByRating(int minRating, int maxRating);

        IEnumerable<HotelModel> GetHotelSearchByName(string searchText);

        IEnumerable<HotelModel> GetHotelsPageOf(int page, int itemsPerPage, IEnumerable<HotelModel> listHotels);

        IEnumerable<HotelModel> GetHotelsPage(int page, int itemsPerPage);

        int GetValidId();

        bool Delete(int id);

        IEnumerable<string> GetListOfDistinctCity();

        HotelResponse FilterHotels(HotelRequest hotelRequest);

    }
}
