using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    class Whale:Mamal
    {
        public Whale(string name)
        {
            Name = name;
        }

        public Whale()
        {
            
        }
        
        public override void Speak()
        {
            Console.WriteLine($"Im a Whale , my name is: {Name}");
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
