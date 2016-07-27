using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApi_.Models;

namespace HotelApi_.ManagerHotel
{
    public class HotelManager
    {
        private HotelManager()
        {
            Hotels = new List<Hotel>();
        }

        public bool Add(Hotel hotel)
        {
            if (hotels.Contains(hotel))
                return false;
            hotels.Add(hotel);
            return true;
        }

        public bool Update(Hotel hotel)
        {
            if (!hotels.Contains(hotel))
                return false;
            int index = hotelManager.Hotels.IndexOf(hotel);
            hotelManager.hotels.RemoveAt(index);
            hotelManager.hotels.Insert(index, hotel);
            return true;
        }

        public void PopulateHotels()
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
        }

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

        public List<Hotel> Hotels
        {
            get { return hotels.ToList(); }
            private set { hotels = value; }
        }

        private static HotelManager hotelManager;

        public static HotelManager GetInstance()
        {
            return hotelManager ?? (hotelManager = new HotelManager());
        }
    }
}