using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part4.Mamals;

namespace Part4
{
    [Serializable()]
    public class Cat : Mamal
    {
        public Cat(string name)
        {
            Name = name;
            HasLegs = true;
        }

        public CatBreeds Breed { get; set; }

        public Cat()
        {

        }

        public Cat(string name, ColorEye colorEyes, CatBreeds breed)
        {
            Name = name;
            ColorEyes = colorEyes;
            Breed = breed;
            HasLegs = true;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Breed:{Breed}");
        }

        public sealed override void Serialize(TextWriter writer)
        {
            base.Serialize(writer);
            writer.Write($",{Breed}\r\n");
        }

        public sealed override IAnimal Deserialize(ReadAheadStreamReader reader)
        {
            Cat cat = (Cat)base.Deserialize(reader);
            var columns = reader.ReadLine().Split(',');
            CatBreeds catBread = (CatBreeds)int.Parse(columns[columns.Length-1]);
            cat.Breed = catBread;
            return cat;
        }

        public override void Speak()
        {
            Console.WriteLine("Meow!");
        }
    }
}
