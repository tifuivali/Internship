using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    public class Cameleon : Reptila
    {
        public Cameleon(string name)
        {
            Name = name;
        }



        public Cameleon()
        {

        }

        public override void Serialize(TextWriter writer)
        {
            base.Serialize(writer);
            writer.Write("\r\n");
        }

        public override IAnimal Deserialize(ReadAheadStreamReader reader)
        {
            Cameleon cameleon = (Cameleon)base.Deserialize(reader);
            reader.ReadLine();
            return cameleon;

        }

        public override void Move()
        {
            Console.WriteLine("I'm walking!");
        }
    }
}
