using System;
using ExercicesPart3;

namespace ExercisePart3
{
    public sealed class Hotel : Proprety
    {
     

        public int Likes { get; set; }

        public Hotel()
        {
            
        }

        public Hotel(string name, string description, string adress, int stars, double distanceToCenter,
            DateTime openingDate, Room[] rooms)
            : base(name, description, adress, stars, distanceToCenter, openingDate, rooms)
        {
            
        }

        public Hotel(string name, string description, string adress, int stars, double distanceToCenter,
         DateTime openingDate, Room[] rooms,int likes)
         : base(name, description, adress, stars, distanceToCenter, openingDate, rooms)
        {
            Likes = likes;
        }

        public void SeHotelAdress(string newAdress)
        {
            base.adress = newAdress;
        }

        public override double CalculateRating() => (int) (Math.Round((double)Likes, 10)/1000*0.3 + 2*Stars*0.7);

        public override void DisplayInfo()
        {
            Console.WriteLine($"Likes: {Likes}");
            base.DisplayInfo();
            Console.WriteLine();
        }
    }
}
