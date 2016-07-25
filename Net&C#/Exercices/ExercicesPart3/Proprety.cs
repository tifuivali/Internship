using ExercisePart3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPart3
{
   public class Proprety
    {
        private string name;
        private string description;
        protected string adress;
        private int stars;
        private double distanceToCenter;
        private DateTime openningDate;
        private Room[] rooms;
        private static string DistanceMeasurementUnit;


        public bool HasFreeWifi { get; set; }

        public bool HasIndoorPool1 { get; set; }

       public Proprety()
       {
           
       }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value.Length > 50)
                    throw new Exception($"Name must be less than 50 characters! Current length:{value.Length}");
                name = value;
            }
        }

        public Proprety(string name, string description, string adress, int stars, double distanceToCenter,
       DateTime openingDate, Room[] rooms)
        {
            Rooms = rooms;
            Name = name;
            Adress = adress;
            Description = description;
            DistanceToCenter = distanceToCenter;
            OpenningDate = openingDate;
            OpenningDate = openingDate;
            Stars = stars;
        }

       public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (value.Length > 500)
                    throw new Exception($"Description must be less than 500 characters! Current length:{value.Length}");
                description = value;
            }
        }

        public string Adress
        {
            get
            {
                return adress;
            }

            set
            {
                if (value.Length > 100)
                    throw new Exception($"Adress must be less than 100 characters! Current length:{value.Length}");
                adress = value;
            }
        }

        public int Stars
        {
            get
            {
                return stars;
            }

            set
            {
                if (value < 0 || value > 5)
                    throw new Exception($"Stars must be between 0 and 5! Current:{value}");
                stars = value;
            }
        }

        public double DistanceToCenter
        {
            get
            {
                return distanceToCenter;
            }

            set
            {
                if (value < 0 || value > 100)
                    throw new Exception($"DistanceToCenter proprety must be between 0 and 5! Current:{value}");
                distanceToCenter = value;
            }
        }

        public DateTime OpenningDate
        {
            get
            {
                return openningDate;
            }

            set
            {
                if (DateTime.Compare(value, new DateTime(1800, 1, 1)) < 0 || DateTime.Compare(value, DateTime.Now) > 0)
                    throw new Exception("OpeningDate proprety must be between 1/1/1800 and " + DateTime.Now.ToShortTimeString());
                openningDate = value;
            }
        }

        public Room[] Rooms
        {
            get
            {
                return rooms.ToArray();
            }

            set
            {
                rooms = value;
            }
        }


       public virtual double CalculateRating()
       {
           return 2*Stars;
       }

        public void SetDistanceMeasurementUnit(string unit)
        {
            DistanceMeasurementUnit = unit;
        }

        public string GetDistanceMeasurementUnit()
        {
            return DistanceMeasurementUnit;
        }

        public virtual void  DisplayInfo()
        {
            Console.WriteLine($"Hotel {Name}");
            Console.WriteLine($"Adress: {Adress}");
            Console.WriteLine($"Distance to center:{DistanceToCenter} {DistanceMeasurementUnit}");
            Console.WriteLine($"Date opening:{OpenningDate.ToShortDateString()}");
            Console.WriteLine($"Stars:{Stars}");
            Console.WriteLine("Rooms:");
            foreach (var room in Rooms)
            {
                room.DisplayInfo();
            }
        }
    }
}

