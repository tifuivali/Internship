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
           Room room1 =new Room("Room 1 description",2,1,1,RoomType.Double);
           Hotel hotel =new Hotel("International","International Description","Str Palat nr 23 Iasi",4,1,new DateTime(1999,2,2),new Room[] {room1} );
           hotel.DisplayInfo();
            Console.ReadKey();
        }
    }
}
