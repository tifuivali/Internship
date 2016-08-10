using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApi_.Entities
{
    public class HotelEntity
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual LocationEntity Location { get; set; }

        public virtual int Rating { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<RoomEntity> Rooms { get; set; }

        public HotelEntity()
        {
            Rooms = new List<RoomEntity>();
            Location = new LocationEntity()
            {
                City = "No City",
                Id=-1
            };
        }
    }
    
}