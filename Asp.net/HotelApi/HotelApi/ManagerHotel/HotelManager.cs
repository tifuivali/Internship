using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HotelApi_.Models;
using HotelApi_.Models.Filter;
using Newtonsoft.Json;

namespace HotelApi_.ManagerHotel
{
    /// <summary>
    /// Hotel Manager Class
    /// </summary>
    public class HotelManager
    {
        /// <summary>
        /// Create a new instance of HotelManager.
        /// </summary>
        private HotelManager()
        {
            Hotels = new List<Hotel>();
        }

        /// <summary>
        /// Add new hotel to list.
        /// </summary>
        /// <param name="hotel">Hotel will be added to list.</param>
        /// <returns>True if opperation secceded , false otherwise.</returns>
        public bool Add(Hotel hotel)
        {
            if (hotels.Contains(hotel))
                return false;
            hotels.Add(hotel);
            return true;
        }

        /// <summary>
        /// Get number of hotels.
        /// </summary>
        public int Count => hotels.Count;

        /// <summary>
        /// Update a hotel with sfecified hotel.
        /// </summary>
        /// <param name="hotel">Hotel that containing the same id with hotel that will be updated.</param>
        /// <returns>True if opperation secceded , false otherwise.</returns>
        public bool Update(Hotel hotel)
        {
            if (!hotels.Contains(hotel))
                return false;
            int index = hotelManager.Hotels.IndexOf(hotel);
            hotelManager.hotels.RemoveAt(index);
            hotelManager.hotels.Insert(index, hotel);
            return true;
        }


        /// <summary>
        /// Get hotels from list that matches specified city.
        /// </summary>
        /// <param name="city">Name of city.</param>
        /// <returns>List of hotels.</returns>
        public IEnumerable<Hotel> GetHotelsByCity(string city)
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
        public IEnumerable<Hotel> GetHotesByRooms(int minRooms, int maxRooms)
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
        public IEnumerable<Hotel> GetHotelByRating(int minRating, int maxRating)
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
        public IEnumerable<Hotel> GetHotelSearchByName(string searchText)
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
        public IEnumerable<Hotel> GetHotelsPageOf(int page, int itemsPerPage, IEnumerable<Hotel> listHotels)
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
        public IEnumerable<Hotel> GetHotelsPage(int page, int itemsPerPage)
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
        public uint GetValidId()
        {
            uint maxId = 0;
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
            Add(new Hotel()
            {
                Id = 1,
                Name = "Hotel Victoria",
                City = "Bucuresti",
                Description = "Un hotel ok",
                Rating = 3,
                RoomsCount = 60
            });

            Add(new Hotel()
            {
                Id = 2,
                City = "Iasi",
                Description = "Plasat in centrul orasului",
                Name = "Hotel Traian",
                Rating = 5,
                RoomsCount = 200
            });

            Add(new Hotel()
            {
                Id = 3,
                City = "Cluj Napoca",
                Description = "Fara",
                Name = "Hotel Europa",
                Rating = 4,
                RoomsCount = 140
            });

            Add(new Hotel()
            {
                Id = (uint)4,
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
                Add(new Hotel()
                {
                    Id = (uint)i,
                    City = listCity[random.Next(0, listCity.Length - 1)],
                    Description = "Fara",
                    Name = names[random.Next(0, names.Length - 1)],
                    Rating = (short)random.Next(0, 5),
                    RoomsCount = (uint)random.Next(20, 250)
                });
            }
        }









        /// <summary>
        /// Delete a hotel by specified id.
        /// </summary>
        /// <param name="id">Id of hotel that will be deleted.</param>
        /// <returns>True if opperattion done , false otherwise. </returns>
        public bool Delete(uint id)
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

        private List<Hotel> hotels;

        /// <summary>
        /// Get or set list of hotels.
        /// </summary>
        public List<Hotel> Hotels
        {
            get { return hotels.ToList(); }
            private set { hotels = value; }
        }

        private static HotelManager hotelManager;

        /// <summary>
        /// Create a instance of HotelManager.
        /// </summary>
        /// <returns>Hotel Manager</returns>
        public static HotelManager GetInstance()
        {
            return hotelManager ?? (hotelManager = new HotelManager());
        }


        private IEnumerable<Hotel> FilderById(IEnumerable<Hotel> hotelsCopy,FilterItem filter)
        {
            int value = int.Parse(filter.Value);
            switch (filter.Operator)
            {
                case "eq":
                    {
                        return hotelsCopy.Where(h => h.Id == value);
                    }
                case "neq":
                    {
                        return hotelsCopy.Where(h => h.Id != value);
                    }
                case "gte":
                    {
                        return hotelsCopy.Where(h => h.Id >= value);
                    }
                case "lte":
                    {
                        return hotelsCopy.Where(h => h.Id <= value);
                    }
                case "gt":
                    {
                        return hotelsCopy.Where(h => h.Id > value);
                    }
                case "lt":
                    {
                        return hotelsCopy.Where(h => h.Id < value);
                    }
            }
            return hotelsCopy;
        }



        private IEnumerable<Hotel> FilterByName(IEnumerable<Hotel> hotelsCopy, FilterItem filter)
        {
            string value = filter.Value;
            value = value.ToUpper();
            switch (filter.Operator)
            {
                case "eq":
                    {
                        return hotelsCopy.Where(h => h.Name.ToUpper() == value);
                    }
                case "neq":
                    {
                        return hotelsCopy.Where(h => h.Name.ToUpper() != value);
                    }
                case "startswith":
                    {
                        return hotelsCopy.Where(h => h.Name.ToUpper().StartsWith(value));
                    }
                case "contains":
                    {
                        return hotelsCopy.Where(h => h.Name.ToUpper().Contains(value));
                    }
                case "doesnotcontain":
                    {
                        return hotelsCopy.Where(h => !h.Name.ToUpper().Contains(value));
                    }
                case "endswith":
                    {
                        return hotelsCopy.Where(h => h.Name.ToUpper().EndsWith(value));
                    }
            }
            return hotelsCopy;
        }

        public IEnumerable<Hotel> FilterHotelByFilterItem(FilterItem filter)
        {
            var hotelsCopy =(IEnumerable<Hotel>) hotels.ToList();
            if (filter.Field != null)
            {
                if (filter.Field == "Id")
                {
                    return FilderById(hotelsCopy, filter);
                }
                if (filter.Field == "Name")
                {
                    return FilterByName(hotelsCopy, filter);
                }
                if (filter.Field == "Description")
                {
                    return FilterByDescription(hotelsCopy, filter);
                }
                if (filter.Field == "RoomsCount")
                {
                    return FilderByRooms(hotelsCopy, filter);
                }
                if (filter.Field == "City")
                {
                    return FilterByCity(hotelsCopy, filter);
                }
                if (filter.Field == "Rating")
                {
                    return FilderByRating(hotelsCopy, filter);
                }
            }
            if (filter.Filters != null)
            {
                if (filter.Logic == "and")
                {
                    foreach (var internFilter in filter.Filters)
                    {
                        hotelsCopy = hotelsCopy.Intersect(FilterHotelByFilterItem(internFilter));
                    }
                    return hotelsCopy;
                }
                if (filter.Logic == "or")
                {
                    foreach (var internFilter in filter.Filters)
                    {
                        hotelsCopy = hotelsCopy.Union(FilterHotelByFilterItem(internFilter));
                    }
                    return hotelsCopy;
                }
                return hotelsCopy;
            }
            return hotelsCopy;
        }


        public IEnumerable<Hotel> FilterHotelsByFilter(Filter filter)
        {
            var hotelsCopy = (IEnumerable<Hotel>) hotels.ToList();
            if (filter.Logic == "and")
            {
                foreach (var internFilter in filter.Filters)
                {
                    hotelsCopy = hotelsCopy.Intersect(FilterHotelByFilterItem(internFilter));
                }
                return hotelsCopy;
            }
            if (filter.Logic == "and")
            {
                foreach (var internFilter in filter.Filters)
                {
                    hotelsCopy = hotelsCopy.Union(FilterHotelByFilterItem(internFilter));
                }
                return hotelsCopy;
            }
            return hotelsCopy;
        }


        private IEnumerable<Hotel> FilterByDescription(IEnumerable<Hotel> hotelsCopy, FilterItem filter)
        {
            string value = filter.Value;
            value = value.ToUpper();
            switch (filter.Operator)
            {
                case "eq":
                    {
                        return hotelsCopy.Where(h => h.Description.ToUpper() == value);
                    }
                case "neq":
                    {
                        return hotelsCopy.Where(h => h.Description.ToUpper() != value);
                    }
                case "startswith":
                    {
                        return hotelsCopy.Where(h => h.Description.ToUpper().StartsWith(value));
                    }
                case "contains":
                    {
                        return hotelsCopy.Where(h => h.Description.ToUpper().Contains(value));
                    }
                case "doesnotcontain":
                    {
                        return hotelsCopy.Where(h => !h.Description.ToUpper().Contains(value));
                    }
                case "endswith":
                    {
                        return hotelsCopy.Where(h => h.Description.ToUpper().EndsWith(value));
                    }
            }
            return hotelsCopy;
        }

        private IEnumerable<Hotel> FilterByCity(IEnumerable<Hotel> hotelsCopy, FilterItem filter)
        {
            string value = filter.Value;
            value = value.ToUpper();
            switch (filter.Operator)
            {
                case "eq":
                    {
                        return hotelsCopy.Where(h => h.City.ToUpper() == value);
                    }
                case "neq":
                    {
                        return hotelsCopy.Where(h => h.City.ToUpper() != value);
                    }
                case "startswith":
                    {
                        return hotelsCopy.Where(h => h.City.ToUpper().StartsWith(value));
                    }
                case "contains":
                    {
                        return hotelsCopy.Where(h => h.City.ToUpper().Contains(value));
                    }
                case "doesnotcontain":
                    {
                        return hotelsCopy.Where(h => !h.City.ToUpper().Contains(value));
                    }
                case "endswith":
                    {
                        return hotelsCopy.Where(h => h.City.ToUpper().EndsWith(value));
                    }
            }
            return hotelsCopy;
        }

        private IEnumerable<Hotel> FilderByRooms(IEnumerable<Hotel> hotelsCopy, FilterItem filter)
        {
            int value = int.Parse(filter.Value);
            switch (filter.Operator)
            {
                case "eq":
                    {
                        return hotelsCopy.Where(h => h.RoomsCount == value);
                    }
                case "neq":
                    {
                        return hotelsCopy.Where(h => h.RoomsCount != value);
                    }
                case "gte":
                    {
                        return hotelsCopy.Where(h => h.RoomsCount >= value);
                    }
                case "lte":
                    {
                        return hotelsCopy.Where(h => h.RoomsCount <= value);
                    }
                case "gt":
                    {
                        return hotelsCopy.Where(h => h.RoomsCount > value);
                    }
                case "lt":
                    {
                        return hotelsCopy.Where(h => h.RoomsCount < value);
                    }
            }
            return hotelsCopy;
        }

        private IEnumerable<Hotel> FilderByRating(IEnumerable<Hotel> hotelsCopy, FilterItem filter)
        {
            int value = int.Parse(filter.Value);
            switch (filter.Operator)
            {
                case "eq":
                    {
                        return hotelsCopy.Where(h => h.Rating == value);
                    }
                case "neq":
                    {
                        return hotelsCopy.Where(h => h.Rating != value);
                    }
                case "gte":
                    {
                        return hotelsCopy.Where(h => h.Rating >= value);
                    }
                case "lte":
                    {
                        return hotelsCopy.Where(h => h.Rating <= value);
                    }
                case "gt":
                    {
                        return hotelsCopy.Where(h => h.Rating > value);
                    }
                case "lt":
                    {
                        return hotelsCopy.Where(h => h.Rating < value);
                    }
            }
            return hotelsCopy;
        }

        public HotelResponse FilterHotels(HotelRequest hotelRequest)
        {
            Filter filter = null;
            if (hotelRequest == null)
                return new HotelResponse()
                {
                    Hotels = hotelManager.GetHotelsPage(1, 10),
                    TotalItems = hotelManager.Count
                };
            if (hotelRequest.Filter != null)
            {
                filter = JsonConvert.DeserializeObject<Filter>(hotelRequest.Filter);
                return new HotelResponse()
                {
                    Hotels = GetHotelsPageOf(hotelRequest.Page,hotelRequest.PageSize,FilterHotelsByFilter(filter)),
                    TotalItems = Hotels.Count
                };
            }



            IEnumerable<Hotel> hotelFiltred = hotelManager.GetHotelSearchByName(hotelRequest.Name)
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
        public IEnumerable<string> GetListOfDistinctCity()
        {
            List<string> cities = new List<string>();
            hotels.ForEach(h => cities.Add(h.City));
            cities = cities.Distinct().ToList();
            return cities;
        }
    }
}