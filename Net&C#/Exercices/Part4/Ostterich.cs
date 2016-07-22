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

        public override void Speak()
        {
            Console.WriteLine($"Im a Ostterich , my name is: {Name}");
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
