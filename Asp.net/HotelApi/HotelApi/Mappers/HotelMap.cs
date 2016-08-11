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
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name);
            Map(x => x.Description);
            HasMany<RoomEntity>(x => x.Rooms).KeyColumns.Add("Id")
                .Not.LazyLoad()
                .Inverse()
                .Cascade.Delete().Cascade.SaveUpdate();


            References(x => x.Location).Column("LocationId")
                .Cascade.SaveUpdate();
                                   
            Map(x => x.Rating);
        }


    }
}