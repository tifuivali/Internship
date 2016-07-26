using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class Ingredient
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        private List<Alergen> alergens;

        public List<Alergen> Alergens
        {
            get { return alergens.ToList(); }
            private set { alergens = value; }
        }
    }
}
