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
    public class Dog:Mamal
    {

        public Dog(string name)
        {
            Name = name;
        }

        public DogBreeds Breed { get; set; }

        public Dog()
        {
            
        }


        public Dog(string name, ColorEye colorEyes, DogBreeds breed)
        {
            Name = name;
            ColorEyes = colorEyes;
            Breed = breed;
            HasLegs = true;
        }


        public override void Serialize(TextWriter writer)
        {
            base.Serialize(writer);
            writer.WriteLine($",{(int) Breed}\r\n");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Breed:{Breed}");
        }

        public override IAnimal Deserialize(ReadAheadStreamReader reader)
        {
            Dog dog = (Dog) base.Deserialize(reader);
            var columns = reader.ReadLine().Split(',');
            DogBreeds breed = (DogBreeds) int.Parse(columns[columns.Length-1]);
            dog.Breed = breed;
            return dog;
        }

        public override void Speak()
        {
            Console.WriteLine("Ham! Ham!");
        }
    }
}
