using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Proudcts.Display;

namespace Products
{
    public abstract class Product
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

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

        protected Product()
        {
            InfoDisplayer = new InfoConseleDisplayer();
            Ingredients = new List<Ingredient>();
        }

        public void Cook()
        {
            PrepareIngredents();
            ShuffleIngredients();
            FinalizeCooking();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Product))
                return false;
            Product product = (Product) obj;
            return this.Id == product.Id;
        }

        public abstract void PrepareIngredents();

        public abstract void ShuffleIngredients();

        public abstract void FinalizeCooking();

    }
}
