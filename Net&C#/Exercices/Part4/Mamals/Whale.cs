using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    [Serializable()]
    class Whale:Mamal
    {
        public Whale(string name)
        {
            Name = name;
        }

       

        public Whale() 
        {
            
        }

        public override void Move()
        {
            Console.WriteLine("I'm swimming!");
        }
    }
}
