using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part4
{
    [Serializable()]
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }

        public abstract void Speak();

        public abstract void Move();

        public static int InstanceCount { get; set; }
    }
}
