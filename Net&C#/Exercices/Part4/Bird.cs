using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part4
{
    [XmlInclude(typeof(Ostterich))]
    [XmlInclude(typeof(Pigeon))]
    [Serializable]
    public abstract class Bird:Animal
    {
        public double FlightSpeed { get; set; }
    }
}
