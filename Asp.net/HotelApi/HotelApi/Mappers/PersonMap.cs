using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using HotelApi_.Entities;

namespace HotelApi_.Mappers
{
    public class PersonMap:ClassMap<PersonEntity>
    {
        public PersonMap()
        {
            Table("Persons");
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.RegisterDate);
            Map(x => x.HasMoney,"HasMoneyToSpend");
            HasMany(x => x.Bookings).KeyColumns.Add("PersonId");
        }
        
    }
}