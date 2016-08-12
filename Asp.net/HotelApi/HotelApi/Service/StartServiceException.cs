using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApi_.Service
{
    public class ServiceActivatorException:Exception
    {
        public ServiceActivatorException(string message) : base(message)
        {
           
        }
    }
}