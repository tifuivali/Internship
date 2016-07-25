using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part4
{
    [Serializable()]
    public abstract class Fish:Animal
    {
        public double SwimingSpeed { get; set; }

        public override void Speak()
        {
            Console.WriteLine("I'm not speaking!");
        }

        public override void Move()
        {
            Console.WriteLine("I'm swimming!");
        }

        public new int InstanceCount { get; set; }

        protected Fish(string name) : base(name)
        {
            Name = name;
        }

        protected Fish()
        {
            
        }
    }
}
