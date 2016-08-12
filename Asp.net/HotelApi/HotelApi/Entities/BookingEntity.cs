using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApi_.Entities
{
    public class BookingEntity
    {
        public virtual int Id { get; set; }

        public virtual DateTime BookingDate { get; set; }

        public virtual HotelEntity Hotels { get; set; }

        public virtual PersonEntity Persons { get; set; }

        public virtual RoomEntity Rooms { get; set; }

        public  virtual LocationEntity Locations { get; set; }
    }
}