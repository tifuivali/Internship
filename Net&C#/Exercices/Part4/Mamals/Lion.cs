using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    public class Lion:Mamal
    {

        public Lion(string name,int age)
        {
            Name = name;
            HasChildrens = false;
            Age = age;
        }

        public int Age { get; set; }

        public bool HasChildrens { get; set; }

        public Lion()
        {
            
        }

        public sealed override void Serialize(TextWriter writer)
        {
            base.Serialize(writer);
            writer.Write($",{Age},{HasChildrens}\r\n");
        }

        public sealed override IAnimal Deserialize(ReadAheadStreamReader reader)
        {
            var lion = (Lion) base.Deserialize(reader);
            var columns = reader.ReadLine().Split(',');
            int age = int.Parse(columns[columns.Length - 2]);
            bool hasChildrens = bool.Parse(columns[columns.Length - 1]);
            lion.Age = age;
            lion.HasChildrens = hasChildrens;
            return lion;
        }

        public override void Speak()
        {
            Console.WriteLine("Roar");
        }

        public override void Move()
        {
           Console.WriteLine("I'm running very fast!");
        }

        public sealed override void DisplayInfo()
        {
            Console.WriteLine($"Has Childrens:{HasChildrens}");
            Console.WriteLine($"Age:{Age}");
        }
    }
}
