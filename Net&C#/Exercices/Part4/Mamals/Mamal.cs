using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Part4.Mamals;

namespace Part4
{
    [Serializable()]
    public abstract class Mamal:Animal
    {
        public bool HasLegs { get; set; }

        public new int InstanceCount { get; set; }

        public ColorEye ColorEyes { get; set; }

        public override void Speak()
        {
            Console.WriteLine("I'm not speaking!");
        }

        public override void Move()
        {
            Console.WriteLine("I'm walk!");
        }

        protected Mamal(string name) : base(name)
        {
            
        }

        protected Mamal()
        {
            
        }

        protected Mamal(string name,ColorEye colorEyes,bool hasLegs)
        {
            Name = name;
            ColorEyes = colorEyes;
            HasLegs = hasLegs;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Has Legs:{HasLegs}");
            Console.WriteLine($"Color Eyes:{ColorEyes}");
        }

        public override void Serialize(TextWriter writer)
        {
            base.Serialize(writer);
            writer.Write($",{HasLegs},{(int)ColorEyes}");
        }

        public override IAnimal Deserialize(ReadAheadStreamReader reader)
        {
            Mamal mamal = (Mamal) base.Deserialize(reader);
            var columns = reader.PeekLine().Split(',');
            bool hasLegs = bool.Parse(columns[columns.Length-1]);
            mamal.HasLegs = hasLegs;
            return mamal;
        }
    }
}
