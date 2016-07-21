using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePart2
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise2();
            Console.WriteLine();

            //Exercise3

            Hotel hotel = CreateHotel();
            //Exercise3
            hotel.DisplayInfo();

            //Exercise4
            Exercise4();

            //Exercise6
            Exercise6();

            Console.ReadKey();
        }

        static void Exercise2()
        {
            Hotel hotel = CreateHotel();
            Console.WriteLine("Name:"+hotel.name);
            Console.WriteLine("Adress:"+hotel.adress);
            Console.WriteLine("Opening year:"+hotel.openningDate.ToShortDateString());
            Console.WriteLine("Total number of rooms:"+hotel.rooms.Length);
        }

        static Hotel CreateHotel()
        {
            Hotel hotel = new Hotel();
            hotel.adress = "Str Palat nr.23 Iasi";
            hotel.description = "Central Hotel";
            hotel.distanceToCenter = 1;
            hotel.name = "Hotel International";
            hotel.openningDate = new DateTime(2006, 7, 2);
            hotel.stars = 5;
            Room room1 = new Room();
            room1.description = "Room 1 description";
            room1.floor = 2;
            room1.number = 12;
            room1.places = 2;
            room1.type = RoomType.Double;
            hotel.rooms = new Room[2];
            hotel.rooms[0] = room1;
            Room room2 = new Room();
            room2.description = "Description room 2";
            room2.floor = 3;
            room2.number = 42;
            room2.places = 6;
            room2.type = RoomType.Duplex;
            hotel.rooms[1] = room2;
            return hotel;
        }

        static void Exercise4()
        {
            Room room1 = new Room("Description room 12", 2, 12, 2, RoomType.Double);
            Room room2 = new Room("Description room 42", 5, 42, 4, RoomType.Duplex);
            var rooms = new []{room1, room2};
            Hotel hotel = new Hotel("Intarnational", "Description hotel Intarnational", "Str Palat nr 23 Iasi", 5, 1, new DateTime(2016, 7, 3), rooms);
            hotel.DisplayInfo();
        }

        static void Exercise6()
        {
            Room room1 = new Room("Description room 11", 2, 11, 2, RoomType.Double);
            Room room2 = new Room("Description room 12", 5, 12, 4, RoomType.Duplex);
            var rooms = new Room[2];
            rooms[0] = room1;
            rooms[1] = room2;
            Hotel hotel = new Hotel("Moldova", "Description hotel Moldova", "Str Palas nr 15 Iasi", 5, 1, new DateTime(1997, 8, 15), rooms);
            Hotel.SetDistanceMeasurementUnit("KM");
            Console.WriteLine("New measure unit is "+Hotel.GetDistanceMeasurementUnit());
            hotel.DisplayInfo();
        }
    }
}
