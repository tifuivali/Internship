using System.IO;
using Products;

namespace Proudcts.Display
{
    public class InfoFileDisplayer : IDisplay
    {

        private readonly string filePath;

        private TextWriter writer;

        public InfoFileDisplayer(string filePath)
        {
            this.filePath = filePath;
        }

        public void DisplayInfo(Product product)
        {
            using (writer = File.CreateText(filePath))
            {
                writer.WriteLine($"ID:{product.Id}");
                writer.WriteLine($"Name:{product.Name}");
                writer.WriteLine($"Description:{product.Description}");
                writer.WriteLine("Ingredients:");
                product.Ingredients.ForEach(item => DisplayIngredient(item, writer));
            }


        }

        private static void DisplayIngredient(Ingredient ingredient, TextWriter writer)
        {
            writer.WriteLine($"Ingredient ID:{ingredient.Id}");
            writer.WriteLine($"Ingredient Name:{ingredient.Name}");
            writer.WriteLine("Alergens:");
            ingredient.Alergens.ForEach(item => DisplayAlergen(item, writer));
        }

        private static void DisplayAlergen(Alergen alergen, TextWriter writer)
        {
            writer.WriteLine($"Alergen ID:{alergen.Id}");
            writer.WriteLine($"Alergen Name:{alergen.Name}");
        }
    }
}
