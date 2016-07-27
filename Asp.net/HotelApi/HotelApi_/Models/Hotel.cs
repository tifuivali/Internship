using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApi_.Models
{
    public class Hotel
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public uint RoomsCount { get; set; }

        public short Rating { get; set; }
    }
}