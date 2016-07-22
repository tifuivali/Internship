using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    public class Lion:Mamal
    {

        public Lion(string name)
        {
            Name = name;
        }

        public Lion()
        {
            
        }

        public override void Speak()
        {
            Console.WriteLine($"Im a Lion, my name is: {Name}");
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
