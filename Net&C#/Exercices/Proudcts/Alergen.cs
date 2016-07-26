using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class Alergen
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public Alergen()
        {
            
        }

        public Alergen(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Alergen))
                return false;
            Alergen alergen = (Alergen) obj;
            return alergen.Id == this.Id;
        }
    }
}
