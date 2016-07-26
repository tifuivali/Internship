using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Categories
{
    public class DairyProduct:Product
    {
        public string PresentYourself()
        {
            return "A dairy product or milk product is food produced from the milk of mammals, primarily cows," +
                   " water buffaloes, goats, sheep, yaks, horses, camels, and domestic buffaloes. A facility that" +
                   " processes milk is a dairy or a dairy factory. Dairy products are commonly found in European," +
                   " Middle Eastern, South Asian, and Central Asian cuisines, but are largely absent from East Asian" +
                   " and Southeast Asian cuisines.";
        }

        public override void PrepareIngredents()
        {
            Console.WriteLine("DairyProduct");
            Console.WriteLine("Preapare Ingredients:");
            Ingredients.ForEach(Console.WriteLine);
        }

        public override void ShuffleIngredients()
        {
            Console.WriteLine("Shuffle ingredients...");
        }

        public override void FinalizeCooking()
        {
            Console.WriteLine("Finalize Cooking");
        }
    }
}
