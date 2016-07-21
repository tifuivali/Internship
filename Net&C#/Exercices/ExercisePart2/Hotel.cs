using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePart2
{
    public class Hotel
    {
        public string name;
        public string description;
        public string adress;
        public int stars;
        public double distanceToCenter;
        public DateTime openningDate;
        public Room[] rooms;
        private static string DistanceMeasurementUnit;


        static Hotel()
        {
            DistanceMeasurementUnit = "Miles";
        }

        public Hotel()
        {
           
        }

        public Hotel(string name, string description, string adress, int stars, double distanceToCenter,
                DateTime openingDate, Room[] rooms)
        {
            this.rooms = rooms;
            this.name = name;
            this.adress = adress;
            this.description = description;
            this.distanceToCenter = distanceToCenter;
            this.openningDate = openingDate;
            this.stars = stars;
        }

        public static void  SetDistanceMeasurementUnit(string unit)
        {
            DistanceMeasurementUnit = unit;
        }

        public static string GetDistanceMeasurementUnit()
        {
            return DistanceMeasurementUnit;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Hotel " + this.name);
            Console.WriteLine("Adress: " + this.adress);
            Console.WriteLine($"Distance to center:{this.distanceToCenter} {DistanceMeasurementUnit}");
            Console.WriteLine("Date opening:" + this.openningDate.ToShortDateString());
            Console.WriteLine("Stars:" + this.stars);
            Console.WriteLine("Rooms:");
            foreach (var room in this.rooms)
            {
                room.DisplayInfo();
                Console.WriteLine();

            }
        }
    }
}
