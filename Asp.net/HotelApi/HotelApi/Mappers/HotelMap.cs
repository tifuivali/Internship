using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using HotelApi_.Entities;

namespace HotelApi_.Mappers
{
    public class HotelMap : ClassMap<HotelEntity>
    {
        public HotelMap()
        {
            Table("Hotels");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            HasMany<RoomEntity>(x => x.Rooms).KeyColumns.Add("Id")
                                             .Cascade.AllDeleteOrphan();
            References(x => x.Location).Column("LocationId");
            Map(x => x.Rating);
        }


    }
}