using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePart2
{
    public class Room
    {
        public string description;
        public int places;
        public int number;
        public int floor;
        public RoomType type;

        public Room()
        {
        }

        public Room(string description, int places, int number, int floor, RoomType type)
        {
            this.number = number;
            this.description = description;
            this.floor = floor;
            this.places = places;
            this.type = type;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("\tRoom " + this.number);
            Console.WriteLine("\tDescription: " + this.description);
            Console.WriteLine("\tFloor:" + this.floor);
            Console.WriteLine("\tPlaces:" + this.places);
            Console.WriteLine("\tRoom Type:" + this.type);
            Console.WriteLine();
        }
    }
}
