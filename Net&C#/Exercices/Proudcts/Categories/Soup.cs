using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Categories
{
    public class Soup : Product
    {
        public string PresentYourself()
        {
            return "Soup is a primarily liquid food, generally served warm (but may be cool or cold), " +
                   "that is made by combining ingredients such as meat and vegetables with stock, juice, water, or another" +
                   " liquid. Hot soups are additionally characterized by boiling solid ingredients in liquids " +
                   "in a pot until the flavors are extracted, forming a broth.";
        }

        public override void PrepareIngredents()
        {
            Console.WriteLine("Soup");
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
