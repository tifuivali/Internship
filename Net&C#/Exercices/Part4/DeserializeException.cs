using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    public class DeserializeException:Exception
    {
        public DeserializeException(string message):base(message)
        {
            
        }
    }

}
