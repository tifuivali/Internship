using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    public class Pastrav : Fish
    {
        public Pastrav(string name)
        {
            Name = name;
        }

        public Pastrav()
        {

        }
        public override void Speak()
        {
            Console.WriteLine($"Im a Pastrav , my name is: {Name}");
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
