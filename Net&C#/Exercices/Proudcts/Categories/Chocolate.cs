using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class Chocolate:Product
    {
        public string PresentYourself()
        {
            return "Chocolatis a typically sweet, usually brown, food preparation of Theobroma cacao seeds, " +
                   "roasted and ground, often flavored, as with vanilla. It is made in the form of a liquid, " +
                   "paste, or in a block, or used as a flavoring ingredient in other foods. " +
                   "Cacao has been cultivated by many culture for at least three millennia in Mesoamerica." +
                   " The earliest evidence of use traces to the Mokaya (Mexico and Guatemala), with evidence " +
                   "of chocolate beverages dating back to 1900 BCE.[1] In fact, the majority of Mesoamerican people" +
                   " made chocolate beverages, including the Maya and Aztecs,[2] who made it into a beverage known" +
                   " as xocolātl Nahuatl pronunciation: [ʃoˈkolaːt͡ɬ], a Nahuatl word meaning 'bitter water'." +
                   " The seeds of the cacao tree have an intense bitter taste and must be fermented to develop the flavor.";
        }

        public override void PrepareIngredents()
        {
            Console.WriteLine("Chocolate");
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
