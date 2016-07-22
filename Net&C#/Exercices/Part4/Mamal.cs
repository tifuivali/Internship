using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part4
{
    [Serializable()]
    public abstract class Mamal:Animal
    {
        public bool HasLegs { get; set; }
    }
}
