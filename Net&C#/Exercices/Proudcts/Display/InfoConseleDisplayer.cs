using System;
using Products;

namespace Proudcts.Display
{
    public class InfoConseleDisplayer : IDisplay
    {
        public void DisplayInfo(Product product)
        {
            Console.WriteLine($"ID:{product.Id}");
            Console.WriteLine($"Name:{product.Name}");
            Console.WriteLine($"Description:{product.Description}");
            Console.WriteLine("Ingredients:");
            product.Ingredients.ForEach(DisplayIngredioent);

        }

        private static void DisplayIngredioent(Ingredient ingredient)
        {
            Console.WriteLine($"Ingredient ID:{ingredient.Id}");
            Console.WriteLine($"Ingredient Name:{ingredient.Name}");
            Console.WriteLine("Alergens:");
            ingredient.Alergens.ForEach(DisplayAlergen);
        }

        private static void DisplayAlergen(Alergen alergen)
        {
            Console.WriteLine($"Alergen ID:{alergen.Id}");
            Console.WriteLine($"Alergen Name:{alergen.Name}");
        }

    }
}
