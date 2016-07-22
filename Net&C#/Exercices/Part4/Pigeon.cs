using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override void Speak()
        {
            Console.WriteLine($"Im a pigeon , my name is: {Name}");
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
