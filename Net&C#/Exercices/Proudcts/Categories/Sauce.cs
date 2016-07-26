using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products;

namespace Proudcts.Categories
{
    public class Sauce : Product
    {

        public string PresentYourSelf()
        {
            return "In cooking, a sauce is liquid, cream, or semi-solid food served on" +
                   " or used in preparing other foods. Sauces are not normally consumed by " +
                   "themselves; they add flavor, moisture, and visual appeal to another dish. " +
                   "Sauce is a French word taken from the Latin salsa, meaning salted. Possibly the " +
                   "oldest sauce recorded is garum, the fish sauce used by the Ancient Greeks.";
        }

        public override void PrepareIngredents()
        {
            Console.WriteLine("Sauce");
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
