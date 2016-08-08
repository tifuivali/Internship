using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApi_.Models.Filter
{
    public class Filter
    {
        public string Logic { get; set; }

        public IEnumerable<FilterItem> Filters { get; set; }
    }
}