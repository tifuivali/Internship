using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proudcts.Display
{
    public class DisplayException : Exception
    {
        public DisplayException(string message) : base(message)
        {
        }
    }
}
