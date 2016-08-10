using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public override bool Delete(int id)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = "DeleteHotel";
            cmd.Connection = connection;
            cmd.CommandType=CommandType.StoredProcedure;
            var idParam = new SqlParameter("@id",(int) id);
            cmd.Parameters.Add(idParam);
            cmd.ExecuteNonQuery();
            return true;
        }

        public static HotelDbManager GetInstance()
        {
            if (hotelDbManagermanager == null)
                hotelDbManagermanager = new HotelDbManager();
            return hotelDbManagermanager;
        }

        public override IEnumerable<string> GetListOfDistinctCity()
        {
            SqlCommand cmd = new SqlCommand("select distinct City from Locations", connection);
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
            if (hotelRequest.Name == null)
                hotelRequest.Name = "";
            if (hotelRequest.City == null)
                hotelRequest.City = "";
            IEnumerable<HotelModel> hotels;
            var cmd = new SqlCommand();
            cmd.CommandText = "FilterHotels";
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Connection = connection;
            var pageParam = new SqlParameter("@page",hotelRequest.Page);
            var pageSizeParam = new SqlParameter("@pageSize",hotelRequest.PageSize);
            var nameParam = new SqlParameter("@name",hotelRequest.Name);
            var cityParam =new SqlParameter("@city",hotelRequest.City);
            var minRoomsParam = new SqlParameter("@minRooms",hotelRequest.MinRoomsCount);
            var maxRoomsParam = new SqlParameter("@maxRooms",hotelRequest.MaxRoomsCount);
            var minRatingParam = new SqlParameter("@minRating",hotelRequest.MinRating);
            var maxRatingParam = new SqlParameter("@maxRating",hotelRequest.MaxRating);
            cmd.Parameters.AddRange(new []{pageParam,nameParam,pageSizeParam,cityParam,minRoomsParam,maxRoomsParam,minRatingParam,maxRatingParam});
            hotels = GetHotelsFromSqlComand(cmd);
            var response = new HotelResponse()
            {
                Hotels = hotels,
                TotalItems = hotels.Count()
            };
            return response;
        }

        private SqlParameter[] GetHotelBindParams(HotelModel hotelModel)
        {
            var idHotelParam = new SqlParameter("@id",(int) hotelModel.Id);
            var nameHotelParam = new SqlParameter("@name",hotelModel.Name);
            var descriprionParam = new SqlParameter("@description", hotelModel.Description);
            var cityParam = new SqlParameter("@city", hotelModel.City);
            var roomsCountParam = new SqlParameter("@roomsCount",(int) hotelModel.RoomsCount);
            var ratingParam = new SqlParameter("@rating",(int) hotelModel.Rating);
            return new[] { idHotelParam,nameHotelParam, descriprionParam, cityParam, roomsCountParam, ratingParam };
        }

        public override bool Add(HotelModel hotelModel)
        {
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "AddNewHotel";
            cmd.CommandType = CommandType.StoredProcedure;

            //bind params

            cmd.Parameters.AddRange(GetHotelBindParams(hotelModel));

            //execute
            cmd.ExecuteNonQuery();
            return true;
        }

        public override bool Update(HotelModel hotelModel)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UpdateHotel";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(GetHotelBindParams(hotelModel));
            cmd.ExecuteNonQuery();
            return true;
        }

        private IEnumerable<HotelModel> GetHotelsFromSqlComand(SqlCommand cmd)
        {
            List<HotelModel> hotels = new List<HotelModel>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                   
                    var hotel = new HotelModel()
                    {
                        City = (string)reader["City"],
                        Description = (string)reader["Description"],
                        Id = (int)reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = (string)reader["Name"],
                        Rating = (short)reader.GetInt32(reader.GetOrdinal("Rating")),
                        RoomsCount = (int)reader.GetInt32(reader.GetOrdinal("RoomsCount"))
                    };
                    
                    hotels.Add(hotel);
                }
            }
            return hotels;
        }

        public override IEnumerable<HotelModel> GetHotelsByCity(string city)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "GetHotelsByCity";
            cmd.CommandType = CommandType.StoredProcedure;
            var cityNameParam = new SqlParameter("@cityName", city);
            cmd.Parameters.Add(cityNameParam);
            return GetHotelsFromSqlComand(cmd);

        }

        public override IEnumerable<HotelModel> GetHotesByRooms(int minRooms, int maxRooms)
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

        public override IEnumerable<HotelModel> GetHotelByRating(int minRating, int maxRating)
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

        public override IEnumerable<HotelModel> GetHotelSearchByName(string searchText)
        {
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "GetHotelsByName";
            cmd.CommandType = CommandType.StoredProcedure;
            var nameParam = new SqlParameter("@name", searchText);
            cmd.Parameters.Add(nameParam);
            return GetHotelsFromSqlComand(cmd);
        }

        public override IEnumerable<HotelModel> GetHotelsPage(int page, int itemsPerPage)
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

        public override int GetValidId()
        {
            var cmd = new SqlCommand("select max(Id) from Hotels", connection);
            int id = (int)(int)cmd.ExecuteScalar();
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