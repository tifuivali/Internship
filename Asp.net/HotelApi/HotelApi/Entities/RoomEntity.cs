using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Conventions.Helpers;

namespace HotelApi_.Entities
{
    public class RoomEntity
    {
        public virtual int Id { get; set; }

        public virtual int HotelId{ get; set; }


    }
}