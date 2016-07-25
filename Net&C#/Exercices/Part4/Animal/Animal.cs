using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part4
{
    [Serializable()]
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public virtual void Serialize(TextWriter writer)
        {
            writer.Write($"{this.GetType().Name},{Name}");
        }


        public Animal(string name)
        {
            Name = name;
        }

        public Animal()
        {
            
        }

        public virtual IAnimal Deserialize(ReadAheadStreamReader reader)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            var readLine = reader.PeekLine();
            var coumns = readLine.Split(',');
            var type = coumns[0];
            if (readLine != null)
            {
                if (type != this.GetType().Name)
                    throw new DeserializeException(
                        $"The object cannot be serialized! Curent type is {type} , expected type {this.GetType().Name}");
            }
            Type t = Type.GetType($"{this.GetType().Namespace}.{type}");
            IAnimal animal = (Animal) Activator.CreateInstance(t);
            animal.Name = coumns[1];
            return animal;
        }

        public abstract void Speak();

        public abstract void Move();

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Type:{this.GetType().Name}");
            Console.WriteLine($"Name:{Name}");
        }

        public static int InstanceCount { get; set; }
    }
}
