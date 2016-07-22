using System;
using System.Collections.Generic;
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

        public Meduza()
        {
            
        }

        public override void Speak()
        {
            Console.WriteLine($"Im a meduza , my name is: {Name}");
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
