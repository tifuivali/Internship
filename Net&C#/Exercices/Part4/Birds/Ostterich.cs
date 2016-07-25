using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    public class Ostterich : Bird
    {
        public Ostterich(string name)
        {
            Name = name;
        }

        public int Speed { get; set; }

        public  double Height { get; set; }

        public Ostterich(string name, int speed, double height)
        {
            Name = name;
            Speed = speed;
            Height = height;
        }

        public override void Serialize(TextWriter writer)
        {
            base.Serialize(writer);
            writer.Write($",{Speed},{Height}\r\n");
        }

        public override IAnimal Deserialize(ReadAheadStreamReader reader)
        {
            Ostterich osterich =(Ostterich) base.Deserialize(reader);
            var columns = reader.ReadLine().Split(',');
            int speed = int.Parse(columns[columns.Length-2]);
            double Height = double.Parse(columns[columns.Length-1]);
            osterich.Height = Height;
            osterich.Speed = speed;
            return osterich;
        }

        public sealed override void DisplayInfo()
        {
            Console.WriteLine($"Speed:{Speed}");
            Console.WriteLine($"Height:{Height}");
        }

        public override void Move()
        {
           Console.WriteLine("I'm running.");
        }
    }
}
