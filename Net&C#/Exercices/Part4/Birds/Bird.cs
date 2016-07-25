using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part4
{
    [Serializable]
    public abstract class Bird:Animal
    {
        public double FlightSpeed { get; set; }

        public new int InstanceCount { get; set; }

        public override void Speak()
        {
            Console.WriteLine("I'm not speaking!");
        }

        public override void Move()
        {
            Console.WriteLine("I'm flying!");
        }

        public Bird(string name) : base(name)
        {
        }

        public Bird()
        {
            
        }
    }
}
