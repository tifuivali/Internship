using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using HotelApi_.Entities;

namespace HotelApi_.Mappers
{
    public class BookingMap:ClassMap<BookingEntity>
    {
        public BookingMap()
        {
            Table("Bookings");
            Id(x => x.Id);
            Map(x => x.BookingDate);
            References(x => x.Persons).Column("PersonId");
        }
    }
}