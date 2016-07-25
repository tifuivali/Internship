using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    public class Pastrav : Fish
    {
        public Pastrav(string name,int swimingSpeed)
        {
            Name = name;
            SwimingSpeed = swimingSpeed;
        }

        public double Length { get; set; }
        public double Weight { get; set; }


        public Pastrav()
        {
         
        }

        public Pastrav(string name, double lenght, double weight)
        {
            Name = name;
            Length = lenght;
            Weight = weight;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Length:{Length}");
            Console.WriteLine($"Weight:{Weight}");
        }

        public sealed override void Serialize(TextWriter writer)
        {
            base.Serialize(writer);
            writer.Write($",{Length},{Weight}\r\n");
        }

        public sealed override IAnimal Deserialize(ReadAheadStreamReader reader)
        {
            Pastrav pastrav = (Pastrav) base.Deserialize(reader);
            var columns = reader.ReadLine().Split(',');
            double length = double.Parse(columns[columns.Length-2]);
            double weight = double.Parse(columns[columns.Length-1]);
            pastrav.Length = length;
            pastrav.Weight = weight;
            return pastrav;
        }
    }
}
