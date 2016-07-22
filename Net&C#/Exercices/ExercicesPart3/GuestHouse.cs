using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercisePart3;

namespace ExercicesPart3
{
    public sealed class GuestHouse:Proprety
    {

        public int ComfortIndex { get; set; }

        public GuestHouse(string name, string description, string adress, int stars, double distanceToCenter,
            DateTime openingDate, Room[] rooms)
            : base(name, description, adress, stars, distanceToCenter, openingDate, rooms)
        {

        }

        public GuestHouse(string name, string description, string adress, int stars, double distanceToCenter,
         DateTime openingDate, Room[] rooms,int comfortIndex)
         : base(name, description, adress, stars, distanceToCenter, openingDate, rooms)
        {
            ComfortIndex = comfortIndex;
        }

        public sealed override double CalculateRating() => ComfortIndex*0.6 + 2*Stars*0.4;

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Comfort Index:{ComfortIndex}");
            Console.WriteLine();
        }
    }
}
