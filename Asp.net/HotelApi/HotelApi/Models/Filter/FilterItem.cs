using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApi_.Models.Filter
{
    public class FilterItem
    {
        public IEnumerable<FilterItem> Filters { get; set; }
        public  string Logic { get; set; }
        public string Field { get; set; }
        public string Operator { get; set; }
        public  string Value { get; set; }
    }
}