using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using FluentNHibernate.Utils;
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
            var session = NHibernateHelper.GetSession();
            
                using (var transaction = session.BeginTransaction())
                {
                    var locationId = session.Query<LocationEntity>()
                        .Max(x => x.Id);

                    var location = new LocationEntity()
                    {
                        Id = locationId + 1,
                        City = hotelModel.City
                    };
                    var rooms = new RoomEntity[1];
                    rooms[0] = new RoomEntity();
                    rooms[0].HotelId = hotelModel.Id;


                    session.Save(location);
                    var hotel = new HotelEntity()
                    {
                        Id = hotelModel.Id,
                        Description = hotelModel.Description,
                        Location = location,
                        Name = hotelModel.Name,
                        Rating = hotelModel.Rating,
                        Rooms = rooms
                    };
                    session.Save(hotel);
                    transaction.Commit();
                }
                return true;
        }



        public override bool Update(HotelModel hotelModel)
        {
            var session = NHibernateHelper.GetSession();
            {
                using (var transaction = session.BeginTransaction())
                {
                    var hotel = session.Get<HotelEntity>(hotelModel.Id);
                    hotel.Description = hotelModel.Description;
                    hotel.Location.City = hotel.Location.City;
                    hotel.Name = hotelModel.Name;
                    hotel.Rating = hotelModel.Rating;
                    session.Update(hotel);
                    transaction.Commit();
                }
            }
            return true;
        }

        public override IEnumerable<HotelModel> GetHotelsByCity(string city)
        {
            return NHibernateHelper.GetSession().Query<HotelEntity>()
                .Where(x => x.Location.City.Trim().ToUpper().Contains(city.Trim().ToUpper()))
                .Select(x => new HotelModel(x)).ToList();
        }

        public override IEnumerable<HotelModel> GetHotesByRooms(int minRooms, int maxRooms)
        {
            return NHibernateHelper.GetSession().Query<HotelEntity>()
                .Where(x => x.Rooms.Count >= minRooms && x.Rooms.Count <= maxRooms)
                .Select(x => new HotelModel(x)).ToList();
        }

        public override IEnumerable<HotelModel> GetHotelByRating(int minRating, int maxRating)
        {
            var session = NHibernateHelper.GetSession();
            var query = session.Query<HotelEntity>()
                .Where(x => x.Rating >= minRating && x.Rating <= maxRating)
                .Select(x => new HotelModel(x));
            return query.ToList();
        }

        public override IEnumerable<HotelModel> GetHotelSearchByName(string searchText)
        {
            var session = NHibernateHelper.GetSession();
            var query = session.Query<HotelEntity>()
                .Where(x => x.Name.ToUpper().Trim().Contains(searchText.ToUpper().Trim()))
                .Select(x => new HotelModel(x));
            return query.ToList();
        }

        public override IEnumerable<HotelModel> GetHotelsPage(int page, int itemsPerPage)
        {
            var session = NHibernateHelper.GetSession();
            var query = session.Query<HotelEntity>()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new HotelModel(x));
            return query.ToList();
        }

        public override int GetValidId()
        {
            var session = NHibernateHelper.GetSession();
            {
                var query = session.Query<HotelEntity>()
                            .Max(x => x.Id);
                return query + 1;
            }
        }

        public override bool Delete(int id)
        {
            var session = NHibernateHelper.GetSession();
            {
                using (var transaction = session.BeginTransaction())
                {
                    var hotel = session.Load<HotelEntity>(id);
                    var rooms = session.Query<RoomEntity>()
                        .Where(x => x.HotelId == hotel.Id);
                    foreach (var room in rooms.ToList())
                    {
                        session.Delete(room);
                    }
                    session.Delete(hotel);
                    transaction.Commit();
                }
            }
            return true;
        }



        public override IEnumerable<string> GetListOfDistinctCity()
        {
            var session = NHibernateHelper.GetSession();
            var query = session.Query<LocationEntity>()
                .Select(x => x.City)
                .Distinct();
            var cities = query.ToList();
            return cities;
        }

        public override HotelResponse FilterHotels(HotelRequest hotelRequest)
        {
            var session = NHibernateHelper.GetSession();
            if (hotelRequest.Name == null)
                hotelRequest.Name = "";
            if (hotelRequest.City == null)
                hotelRequest.City = "";
            if (hotelRequest.MaxRating == 0)
                hotelRequest.MaxRating = 2000;
            if (hotelRequest.MaxRoomsCount == 0)
                hotelRequest.MaxRoomsCount = 2000;
            var query = session.Query<HotelEntity>()
                .Where(x => x.Name.ToUpper().Trim().Contains(hotelRequest.Name.ToUpper().Trim()))
                .Where(x => x.Location.City.ToUpper().Trim().Contains(hotelRequest.City.ToUpper().Trim()))
                .Where(x => x.Rating >= hotelRequest.MinRating && x.Rating <= hotelRequest.MaxRating)
                .Where(
                    x => x.Rooms.Count >= hotelRequest.MinRoomsCount && x.Rooms.Count <= hotelRequest.MaxRoomsCount)
                .Skip((hotelRequest.Page - 1) * hotelRequest.PageSize)
                .Take(hotelRequest.PageSize)
                .Select(x => new HotelModel(x));
            var queyCount = session.Query<HotelEntity>()
                           .Count();


            var hotels = query.ToList();
            var count = queyCount;
            return new HotelResponse()
            {
                Hotels = hotels,
                TotalItems = count
            };

        }
    }
}
