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

        public Hotel()
        {
        }

        public Hotel(string name, string description, string adress, int stars, double distanceToCenter,
                DateTime openingDate, Room[] rooms)
        {
            if (DistanceMeasurementUnit == null)
            {
                DistanceMeasurementUnit = "Miles";
            }
            this.rooms = rooms;
            this.name = name;
            this.adress = adress;
            this.description = description;
            this.distanceToCenter = distanceToCenter;
            this.openningDate = openingDate;
            this.stars = stars;
        }

        public void  SetDistanceMeasurementUnit(string unit)
        {
            DistanceMeasurementUnit = unit;
        }

        public string GetDistanceMeasurementUnit()
        {
            return DistanceMeasurementUnit;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Hotel " + this.name);
            Console.WriteLine("Adress: " + this.adress);
            Console.WriteLine("Distance to center:{0} {1}",this.distanceToCenter,DistanceMeasurementUnit);
            Console.WriteLine("Date opening:" + this.openningDate.ToShortDateString());
            Console.WriteLine("Stars:" + this.stars);
            Console.WriteLine("Rooms:");
            foreach (var room in this.rooms)
            {
                room.DisplayInfo();
            }
            Console.WriteLine();
        }
    }
}
