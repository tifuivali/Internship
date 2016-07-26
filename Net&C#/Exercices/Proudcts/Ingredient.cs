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
            set { alergens = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Ingredient))
                return false;
            Ingredient ingredient = (Ingredient)obj;
            return ingredient.Id == this.Id;
        }
    }
}
