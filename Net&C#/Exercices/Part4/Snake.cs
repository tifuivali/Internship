using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    public class Snake : Reptila
    {
        public Snake(string name)
        {
            Name = name;
        }

        public Snake()
        {
            
        }

        public override void Speak()
        {
            Console.WriteLine($"Im a snake , my name is: {Name}");
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
