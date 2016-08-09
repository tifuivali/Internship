using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HotelApi_.Models;

namespace HotelApi_.ManagerHotel
{
    public class HotelDbManager : HotelManager
    {
        private static SqlConnection connection;
        private static HotelDbManager hotelDbManagermanager;

        private HotelDbManager()
        {
            connection =
                new SqlConnection("Data Source =IASI-H5BP4G7;Initial Catalog=Bookings;User ID=sa;Password=1234%asd");
            connection.Open();
        }

        public override bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public static override HotelManager GetInstance()
        {
            if (hotelDbManagermanager == null)
                hotelDbManagermanager = new HotelDbManager();
            return hotelDbManagermanager;
        }

        public override IEnumerable<string> GetListOfDistinctCity()
        {
            SqlCommand cmd = new SqlCommand("select dinstinct from Locations", connection);
            List<string> cities = new List<string>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cities.Add((string)reader["City"]);
                }
            }
            return (IEnumerable<string>)cities;
        }

        public override HotelResponse FilterHotels(HotelRequest hotelRequest)
        {
            
        }

        private SqlParameter[] GetHotelBindParams(Hotel hotel)
        {
            var idHotelParam = new SqlParameter("@id", hotel.Id);
            var descriprionParam = new SqlParameter("@description", hotel.Description);
            var cityParam = new SqlParameter("@city", hotel.City);
            var roomsCountParam = new SqlParameter("@roomsCount", hotel.RoomsCount);
            var ratingParam = new SqlParameter("@rating", hotel.Rating);
            return new[] { idHotelParam, descriprionParam, cityParam, roomsCountParam, ratingParam };
        }

        public override bool Add(Hotel hotel)
        {
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "AddNewHotel";
            cmd.CommandType = CommandType.StoredProcedure;

            //bind params

            cmd.Parameters.AddRange(GetHotelBindParams(hotel));

            //execute
            cmd.ExecuteNonQuery();
            return true;
        }

        public override bool Update(Hotel hotel)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UpdateHotel";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(GetHotelBindParams(hotel));
            cmd.ExecuteNonQuery();
            return true;
        }

        private IEnumerable<Hotel> GetHotelsFromSqlComand(SqlCommand cmd)
        {
            List<Hotel> hotels = null;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var hotel = new Hotel()
                    {
                        City = (string)reader["City"],
                        Description = (string)reader["Description"],
                        Id = (uint)reader["Id"],
                        Name = (string)reader["Name"],
                        Rating = (short)reader["Rating"],
                        RoomsCount = (uint)reader["RoomsCount"]
                    };
                    hotels.Add(hotel);
                }
            }
            return hotels;
        }

        public override IEnumerable<Hotel> GetHotelsByCity(string city)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "GetHotelsByCity";
            cmd.CommandType = CommandType.StoredProcedure;
            var cityNameParam = new SqlParameter("@cityName", city);
            cmd.Parameters.Add(cityNameParam);
            return GetHotelsFromSqlComand(cmd);

        }

        public override IEnumerable<Hotel> GetHotesByRooms(int minRooms, int maxRooms)
        {
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "GetHotelsByRooms";
            cmd.CommandType = CommandType.StoredProcedure;
            var minRoomsParam = new SqlParameter("@minRooms", minRooms);
            var maxRoomsParam = new SqlParameter("@maxRooms", maxRooms);
            cmd.Parameters.AddRange(new[] { minRoomsParam, maxRoomsParam });
            return GetHotelsFromSqlComand(cmd);
        }

        public override IEnumerable<Hotel> GetHotelByRating(int minRating, int maxRating)
        {
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "GetHotelsByRating";
            cmd.CommandType = CommandType.StoredProcedure;
            var minRatingParam = new SqlParameter("@minRating", minRating);
            var maxRatingParam = new SqlParameter("@maxRating", maxRating);
            cmd.Parameters.AddRange(new[] { minRatingParam, maxRatingParam });
            return GetHotelsFromSqlComand(cmd);
        }

        public override IEnumerable<Hotel> GetHotelSearchByName(string searchText)
        {
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "GetHotelsByName";
            cmd.CommandType = CommandType.StoredProcedure;
            var nameParam = new SqlParameter("@name", searchText);
            cmd.Parameters.Add(nameParam);
            return GetHotelsFromSqlComand(cmd);
        }

        public override IEnumerable<Hotel> GetHotelsPage(int page, int itemsPerPage)
        {
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "GetHotelsPage";
            cmd.CommandType = CommandType.StoredProcedure;
            var pageParam = new SqlParameter("@page", page);
            var pageSizeParam = new SqlParameter("@pageSize", itemsPerPage);
            cmd.Parameters.AddRange(new[] { pageParam, pageSizeParam });
            return GetHotelsFromSqlComand(cmd);
        }

        public override uint GetValidId()
        {
            var cmd = new SqlCommand("select max(Id) from Hotels", connection);
            uint id = (uint)cmd.ExecuteScalar();
            return id + 1;
        }

        public new int Count
        {
            get
            {
                SqlCommand cmd = new SqlCommand("select count(*) from Hotels", connection);
                return (int)cmd.ExecuteScalar();
            }
        }





    }
}