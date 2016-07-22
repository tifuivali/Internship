using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    public class Cat:Mamal
    {
        public Cat(string name)
        {
            Name = name;
        }

        public Cat()
        {
            
        }

        public override void Speak()
        {
            Console.WriteLine($"Im a Cat , my name is: {Name}");
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
