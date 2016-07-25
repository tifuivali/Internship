using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part4.Birds;

namespace Part4
{
    [Serializable()]
    public class Pigeon : Bird
    {

        public Pigeon(string name)
        {
            Name = name;
        }

        public Pigeon()
        {
            
        }

        public Color Color { get; set; }

        public bool CanSpeak { get; set; }

        public Pigeon(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Can Speak:{CanSpeak}");
            Console.WriteLine($"Color:{Color}");
        }

        public sealed override void Serialize(TextWriter writer)
        {
            base.Serialize(writer);
            writer.Write($",{(int) Color},{CanSpeak}\r\n");
        }

        public sealed override IAnimal Deserialize(ReadAheadStreamReader reader)
        {
            Pigeon pigeon = (Pigeon) base.Deserialize(reader);
            var columns = reader.ReadLine().Split(',');
            Color color = (Color) int.Parse(columns[columns.Length-2]);
            bool canSpeak = bool.Parse(columns[columns.Length-1]);
            pigeon.CanSpeak = canSpeak;
            pigeon.Color = color;
            return pigeon;
        }

        public override void Speak()
        {
            Console.WriteLine($"Im a pigeon , my name is: {Name}");
        }

    }
}
