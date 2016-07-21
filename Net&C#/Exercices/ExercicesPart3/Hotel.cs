using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExercicesPart3;

namespace ExercisePart3
{
    public sealed class Hotel : Proprety
    {

        public Hotel()
        {
            
        }

        public Hotel(string name, string description, string adress, int stars, double distanceToCenter,
            DateTime openingDate, Room[] rooms)
            : base(name, description, adress, stars, distanceToCenter, openingDate, rooms)
        {
            
        }
    }
}
