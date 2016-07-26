using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    public class ListAnimals : List<Animal>
    {
        public virtual void Serialize(TextWriter writer)
        {
            foreach (var animal in this)
            {
                animal.Serialize(writer);
            }
        }

        public virtual void Deserialize(ReadAheadStreamReader reader)
        {
            string readLine;
            while ((readLine = reader.PeekLine()) != null )
            {
                var columns = readLine.Split(',');
                Type t = Type.GetType($"{this.GetType().Namespace}.{columns[0]}");
                Animal animal = (Animal)Activator.CreateInstance(t);
                animal.Deserialize(reader);
                Add(animal);
            }
        }
    }
}
