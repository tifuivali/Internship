using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Categories
{
    public class FastFood:Product
    {
        public string PresentYourself()
        {
            return "Fast food, a type of mass-produced food that is prepared and served very quickly," +
                   " was first popularized in the 1950s in the United States, and may be relatively less " +
                   "nutritionally valuable compared to other foods and dishes. While any meal with low preparation" +
                   " time can be considered fast food, typically the term refers to food sold in a restaurant " +
                   "or store with preheated or precooked ingredients, and served to the customer in a packaged form " +
                   "for take-out/take-away. Fast food restaurants are traditionally distinguished by their ability to serve " +
                   "food via a drive-through. The term \"fast food\" was recognized in a dictionary by Merriam–Webster in 1951.";
        }

        public override void PrepareIngredents()
        {
            Console.WriteLine("Fast Food");
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
