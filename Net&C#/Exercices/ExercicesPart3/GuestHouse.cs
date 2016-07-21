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
        public GuestHouse(string name, string description, string adress, int stars, double distanceToCenter,
            DateTime openingDate, Room[] rooms)
            : base(name, description, adress, stars, distanceToCenter, openingDate, rooms)
        {

        }
    }
}
