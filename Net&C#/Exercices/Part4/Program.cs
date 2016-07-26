using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Part4.Birds;
using Part4.Mamals;

namespace Part4
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> listAnimals = new List<Animal>();
            Lion lion = new Lion("Lion L", 7);
            Pigeon pigeon = new Pigeon("Jonny");
            Cameleon cameleon = new Cameleon();
            listAnimals.Add(lion);
            listAnimals.Add(pigeon);
            listAnimals.Add(cameleon);
            const string fileName = @"E:\Repos\Net&C#\working dir\serial.csv";

            lion.ColorEyes=ColorEye.Brown;
            lion.HasChildrens = true;
            cameleon.Name = "Cameleon";
            pigeon.Name = "John";
            pigeon.Color=Color.Green;
            pigeon.CanSpeak = true;
            ListAnimals animals =new ListAnimals();
            
            using (TextWriter writer = File.CreateText(fileName))
            {
                animals.Add(lion);
                animals.Add(pigeon);
                animals.Add(cameleon);
                animals.Serialize(writer);
            }

            
            using (ReadAheadStreamReader reader = new ReadAheadStreamReader(File.OpenText(fileName)))
            {
               animals.Deserialize(reader);
                Console.WriteLine($"Length animals:{animals.Count}");
                foreach (var animal in animals)
                {
                    animal.DisplayInfo();
                    Console.WriteLine();
                }
            }
            
            Console.ReadKey();


        }



        public static List<Mamal> GetMamals(List<Animal> listAnimals)
        {
            List<Mamal> listMamals = new List<Mamal>();
            foreach (var animal in listAnimals)
            {
                Console.WriteLine(animal.GetType());
                if (animal.GetType() == typeof(Mamal))
                {
                    listMamals.Add((Mamal)animal);
                }
            }
            return listMamals;
        }


        public static void ExerciseTest(List<Animal> listAnimals, string fileName)
        {
            Searialize(listAnimals, fileName);

            List<Animal> animalsDeserialized = Deserialize(fileName);

            foreach (var animal in animalsDeserialized)
            {
                animal.Speak();
            }


            Console.WriteLine("Mamals:");
            foreach (var mamal in GetMamals(listAnimals))
            {
                Console.WriteLine(mamal.Name);
            }
        }

        public static void Searialize(List<Animal> listAnimals, string fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, listAnimals);
            stream.Close();
        }

        public static List<Animal> Deserialize(string fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            List<Animal> animals = (List<Animal>)binaryFormatter.Deserialize(stream);
            return animals;

        }

    }
}


