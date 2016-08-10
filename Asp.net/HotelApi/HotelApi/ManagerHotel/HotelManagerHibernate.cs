using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using HotelApi_.Entities;
using HotelApi_.Models;
using NHibernate.Linq;

namespace HotelApi_.ManagerHotel
{
    public class HotelManagerHibernate : HotelManager
    {
        private static HotelManagerHibernate hotelManagerHibernate;

        public static HotelManagerHibernate GetInstance()
        {
            if (hotelManagerHibernate == null)
                hotelManagerHibernate = new HotelManagerHibernate();
            return hotelManagerHibernate;
        }
        public override bool Add(HotelModel hotelModel)
        {
            throw new NotImplementedException();
        }

        public override bool Update(HotelModel hotelModel)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<HotelModel> GetHotelsByCity(string city)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<HotelModel> GetHotesByRooms(int minRooms, int maxRooms)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<HotelModel> GetHotelByRating(int minRating, int maxRating)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<HotelModel> GetHotelSearchByName(string searchText)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<HotelModel> GetHotelsPage(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        public override int GetValidId()
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }



        public override IEnumerable<string> GetListOfDistinctCity()
        {
            throw new NotImplementedException();
        }

        public override HotelResponse FilterHotels(HotelRequest hotelRequest)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                if (hotelRequest.Name == null)
                    hotelRequest.Name = "";
                if (hotelRequest.City == null)
                    hotelRequest.City = "";
                if (hotelRequest.MaxRating == 0)
                    hotelRequest.MaxRating = 2000;
                if (hotelRequest.MaxRoomsCount == 0)
                    hotelRequest.MaxRoomsCount = 2000;
                var query = session.Query<HotelEntity>()
                    .Skip(hotelRequest.Page-1)
                    .Take(hotelRequest.PageSize)
                    .Where(x => x.Name.ToUpper().Trim().Contains(hotelRequest.Name.ToUpper().Trim()))
                    .Where(x => x.Location.City.ToUpper().Trim().Contains(hotelRequest.City.ToUpper().Trim()))
                    .Where(x => x.Rating >= hotelRequest.MinRating && x.Rating <= hotelRequest.MaxRating)
                    .Where(
                        x => x.Rooms.Count >= hotelRequest.MinRoomsCount && x.Rooms.Count <= hotelRequest.MaxRoomsCount)
                    .Select(x => new HotelModel()
                    {
                        City = x.Location.City,
                        Description = x.Description,
                        Id =  x.Id,
                        Name = x.Name,
                        Rating = (short)x.Rating,
                        RoomsCount = x.Rooms.Any()?  x.Rooms.Count : 0
                    });
                var hotels = query.ToList();
                return new HotelResponse()
                {
                    Hotels = hotels,
                    TotalItems = hotels.Count
                };

            }
        }
    }
}