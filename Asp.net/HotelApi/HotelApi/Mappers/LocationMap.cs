using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using HotelApi_.Entities;

namespace HotelApi_.Mappers
{
    public class LocationMap:ClassMap<LocationEntity>
    {
        public LocationMap()
        {
            Table("Locations");
            Id(x => x.Id);
            Map(x => x.City);
        }
    }
}