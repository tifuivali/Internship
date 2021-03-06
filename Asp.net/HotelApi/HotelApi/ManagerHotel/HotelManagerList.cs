﻿using System;
using System.Collections.Generic;
using System.Linq;
using HotelApi_.Models;

namespace HotelApi_.ManagerHotel
{
    /// <summary>
    /// Hotel Manager Class
    /// </summary>
    public class HotelManagerList:HotelManager
    {
        /// <summary>
        /// Create a new instance of HotelManager.
        /// </summary>
        private HotelManagerList()
        {
            Hotels = new List<HotelModel>();
        }

        /// <summary>
        /// Add new hotel to list.
        /// </summary>
        /// <param name="hotelModel">Hotel will be added to list.</param>
        /// <returns>True if opperation secceded , false otherwise.</returns>
        public override bool Add(HotelModel hotelModel)
        {
            if (hotels.Contains(hotelModel))
                return false;
            hotels.Add(hotelModel);
            return true;
        }

        /// <summary>
        /// Get number of hotels.
        /// </summary>
        public new int Count => hotels.Count;

        /// <summary>
        /// Update a hotel with sfecified hotel.
        /// </summary>
        /// <param name="hotelModel">Hotel that containing the same id with hotel that will be updated.</param>
        /// <returns>True if opperation secceded , false otherwise.</returns>
        public override bool Update(HotelModel hotelModel)
        {
            if (!hotels.Contains(hotelModel))
                return false;
            int index = hotelManager.Hotels.IndexOf(hotelModel);
            hotelManager.hotels.RemoveAt(index);
            hotelManager.hotels.Insert(index, hotelModel);
            return true;
        }


        /// <summary>
        /// Get hotels from list that matches specified city.
        /// </summary>
        /// <param name="city">Name of city.</param>
        /// <returns>List of hotels.</returns>
        public override IEnumerable<HotelModel> GetHotelsByCity(string city)
        {
            if (city == null)
                return Hotels;
            return hotels.Where(h => h.City == city);
        }

        /// <summary>
        /// Get hotels from list that matches specified inerval of rooms count.
        /// </summary>
        /// <param name="minRooms">Number of minimum numbers of rooms.</param>
        /// <param name="maxRooms">Number of maximum numbers of romms.</param>
        /// <returns>List of hotels.</returns>
        public override IEnumerable<HotelModel> GetHotesByRooms(int minRooms, int maxRooms)
        {
            if (minRooms <= 0 || maxRooms <= 0)
                return Hotels;
            return hotels.Where(h => h.RoomsCount >= minRooms && h.RoomsCount <= maxRooms);
        }

        /// <summary>
        /// Get hotel that matches specified interval of stars.
        /// </summary>
        /// <param name="minRating">Minimum number of stars.</param>
        /// <param name="maxRating">Maximum number of stars.</param>
        /// <returns>List of hotels.</returns>
        public override IEnumerable<HotelModel> GetHotelByRating(int minRating, int maxRating)
        {
            if (minRating <= 0 || maxRating <= 0)
                return Hotels;
            return hotels.Where(h => h.Rating >= minRating && h.Rating <= maxRating);
        }

        /// <summary>
        /// Get hotels that matches specified name.
        /// </summary>
        /// <param name="searchText">Name of hotel.</param>
        /// <returns>List of hotels.</returns>
        public override IEnumerable<HotelModel> GetHotelSearchByName(string searchText)
        {
            if (hotels.Count <= 0)
                PopulateHotels();
            if (searchText == null)
                return Hotels;
            return
                hotels.Where(h => h.Name.ToUpper().Contains(searchText.ToUpper().Trim()));
        }

        /// <summary>
        /// Get elements at specified page of specified list.
        /// </summary>
        /// <param name="page">Number of page.</param>
        /// <param name="itemsPerPage">Page Size.</param>
        /// <param name="listHotels">List of hotels.</param>
        /// <returns>List of hotels.</returns>
        public override IEnumerable<HotelModel> GetHotelsPageOf(int page, int itemsPerPage, IEnumerable<HotelModel> listHotels)
        {

            if (hotels.Count <= 0)
                PopulateHotels();
            int startIndex = itemsPerPage * (page - 1);
            return listHotels.Skip(startIndex).Take(itemsPerPage);
        }

        /// <summary>
        /// Get elements at specified page from hotels list.
        /// </summary>
        /// <param name="page">Number of page.</param>
        /// <param name="itemsPerPage">Page Size.</param>
        /// <returns>List of hotels.</returns>
        public override IEnumerable<HotelModel> GetHotelsPage(int page, int itemsPerPage)
        {

            if (hotels.Count <= 0)
                PopulateHotels();
            int startIndex = itemsPerPage * (page - 1);
            return hotels.Skip(startIndex).Take(itemsPerPage);
        }

        /// <summary>
        /// Retrive a valid(unused) hotel id.
        /// </summary>
        /// <returns>A valid id.</returns>
        public override int GetValidId()
        {
            int maxId = 0;
            foreach (var hotel in hotels)
            {
                if (hotel.Id > maxId)
                {
                    maxId = hotel.Id;
                }
            }
            return maxId + 1;
        }

        private void PopulateHotels()
        {
            Add(new HotelModel()
            {
                Id = 1,
                Name = "Hotel Victoria",
                City = "Bucuresti",
                Description = "Un hotel ok",
                Rating = 3,
                RoomsCount = 60
            });

            Add(new HotelModel()
            {
                Id = 2,
                City = "Iasi",
                Description = "Plasat in centrul orasului",
                Name = "Hotel Traian",
                Rating = 5,
                RoomsCount = 200
            });

            Add(new HotelModel()
            {
                Id = 3,
                City = "Cluj Napoca",
                Description = "Fara",
                Name = "Hotel Europa",
                Rating = 4,
                RoomsCount = 140
            });

            Add(new HotelModel()
            {
                Id = (int)4,
                City = "Cluj Napoca",
                Description = "Fara",
                Name = "Hotel Europa",
                Rating = 4,
                RoomsCount = 140
            });
            string[] listCity = new[]
             {
              "Piatra Neamt", "Sibiu", "Brasov", "Constanta", "Timisoara", "Suceaava", "Botosani"
             };


            string[] names = new[]
             {
                "Hotel Havana", "Hotel Dormund", "Hotel OnSleep", "Hotel PeFelie", "Hotel Inside",
                "Hotel Smecher"
              };
            var random = new Random();
            for (int i = 5; i < 100; i++)
            {
                Add(new HotelModel()
                {
                    Id = (int)i,
                    City = listCity[random.Next(0, listCity.Length-1)],
                    Description = "Fara",
                    Name = names[random.Next(0,names.Length-1)],
                    Rating =(short) random.Next(0,5),
                    RoomsCount =(int) random.Next(20,250)
                });
            }
        }









        /// <summary>
        /// Delete a hotel by specified id.
        /// </summary>
        /// <param name="id">Id of hotel that will be deleted.</param>
        /// <returns>True if opperattion done , false otherwise. </returns>
        public override bool Delete(int id)
        {
            int index = -1;
            for (int i = 0; i < hotels.Count; i++)
            {
                if (hotels[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index < 0)
                return false;
            hotels.RemoveAt(index);
            return true;
        }

        private List<HotelModel> hotels;

        /// <summary>
        /// Get or set list of hotels.
        /// </summary>
        public List<HotelModel> Hotels
        {
            get { return hotels.ToList(); }
            private set { hotels = value; }
        }

        private static HotelManagerList hotelManager;

        /// <summary>
        /// Create a instance of HotelManager.
        /// </summary>
        /// <returns>Hotel Manager</returns>
        public static HotelManagerList GetInstance()
        {
            return hotelManager ?? (hotelManager = new HotelManagerList());
        }

        public override HotelResponse FilterHotels(HotelRequest hotelRequest)
        {
            if (hotelRequest == null)
                return new HotelResponse()
                {
                    Hotels = hotelManager.GetHotelsPage(1, 10),
                    TotalItems = hotelManager.Count
                };
            IEnumerable<HotelModel> hotelFiltred = hotelManager.GetHotelSearchByName(hotelRequest.Name)
                .Intersect(hotelManager.GetHotelByRating(hotelRequest.MinRating, hotelRequest.MaxRating))
                .Intersect(hotelManager.GetHotelsByCity(hotelRequest.City))
                .Intersect(hotelManager.GetHotesByRooms(hotelRequest.MinRoomsCount, hotelRequest.MaxRoomsCount));
            return new HotelResponse()
            {
                Hotels = hotelManager.GetHotelsPageOf(hotelRequest.Page, hotelRequest.PageSize, hotelFiltred),
                TotalItems = hotelFiltred.Count()
            };
        }

        /// <summary>
        /// Get List of distinct cities.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> GetListOfDistinctCity()
        {
            List<string> cities = new List<string>();
            hotels.ForEach(h => cities.Add(h.City));
            cities = cities.Distinct().ToList();
            return cities;
        }
    }
}