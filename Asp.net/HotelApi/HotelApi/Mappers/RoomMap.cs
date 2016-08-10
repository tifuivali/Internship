using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using HotelApi_.Entities;

namespace HotelApi_.Mappers
{
    public class  RoomMap:ClassMap<RoomEntity>
    {
        public RoomMap()
        {
            Table("Rooms");
            Id(x => x.Id);
        }
    }
}