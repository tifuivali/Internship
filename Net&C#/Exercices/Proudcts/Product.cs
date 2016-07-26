using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proudcts.Display;

namespace Products
{
    public class Product
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public  string Description { get; set; }

        private List<Ingredient> ingredients;

        public List<Ingredient> Ingredients
        {
            get { return ingredients.ToList(); }
            private set { ingredients = value; }
        }

        public IDisplay InfoDisplayer { get; set; }

        public void DisplayInfo()
        {
            InfoDisplayer.DisplayInfo(this);
        }

    }
}
