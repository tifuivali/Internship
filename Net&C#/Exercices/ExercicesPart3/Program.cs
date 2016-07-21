using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercisePart3;

namespace ExercicesPart3
{
    class Program
    {
        static void Main(string[] args)
        {
            Room room1 = new Room("Room 1 description", 2, 1, 1, RoomType.Double);
            Hotel hotel = new Hotel("International", "International Description", "Str Palat nr 23 Iasi", 4, 1, new DateTime(1999, 2, 2), new Room[] { room1 });
            hotel.DisplayInfo();

            //Exercise 5
            Hotel hotel2 = new Hotel
            {
                Description = "Description Hotel Moldova",
                OpenningDate = new DateTime(1999, 2, 4),
                Name = "Hotel Moldova",
                Adress = "Str Palat nr 23 Iasi",
                DistanceToCenter = 1,
                HasFreeWifi = true,
                HasIndoorPool1 = false,
                Rooms = new Room[] {room1},
                Stars = 5
            };
            hotel2.DisplayInfo();

            Console.ReadKey();
        }
    }
}
