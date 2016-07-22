using System;
using System.Collections.Generic;
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

        public override void Speak()
        {
            Console.WriteLine($"Im a cameleon , my name is: {Name}");
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
