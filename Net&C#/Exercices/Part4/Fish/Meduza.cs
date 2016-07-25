using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    public class Meduza : Fish
    {
        public Meduza(string name)
        {
            Name = name;
        }

        public bool IsTransparent { get; set; }

        public int NumberOfTerminations { get; set; }

        public Meduza()
        {
            
        }

        public Meduza(string name, int numberOfTerminations)
        {
            Name = name;
            NumberOfTerminations = numberOfTerminations;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Number of terminations:{NumberOfTerminations}");
            Console.WriteLine($"IsTransparent:{IsTransparent}");
        }

        public sealed override void Serialize(TextWriter writer)
        {
            base.Serialize(writer);
            writer.Write($",{NumberOfTerminations},{IsTransparent}\r\n");
        }

        public override IAnimal Deserialize(ReadAheadStreamReader reader)
        {
            Meduza meduza = (Meduza) base.Deserialize(reader);
            var columns = reader.ReadLine().Split(',');
            int numberOfTerminations = int.Parse(columns[columns.Length-2]);
            bool isTransparent = bool.Parse(columns[columns.Length-1]);
            meduza.IsTransparent = isTransparent;
            meduza.NumberOfTerminations = numberOfTerminations;
            return meduza;
        }
    }
}
