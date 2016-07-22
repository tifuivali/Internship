using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    public class Dog:Mamal
    {

        public Dog(string name)
        {
            Name = name;
        }

        public Dog()
        {
            
        }

        public override void Speak()
        {
            Console.WriteLine($"Im a Dog, my name is: {Name}");
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
