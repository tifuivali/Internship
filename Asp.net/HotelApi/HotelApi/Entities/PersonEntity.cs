using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HotelApi_.Entities
{
    public class PersonEntity
    {

        public PersonEntity()
        {
            Bookings=new List<BookingEntity>();
        }

        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual DateTime RegisterDate { get; set; }

        public virtual bool HasMoney { get; set; }

        public virtual IList<BookingEntity> Bookings { get; set; }

        public virtual string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"ID:{Id}");
            builder.AppendLine($"First Name:{FirstName}");
            builder.AppendLine($"Last Name:{LastName}");
            builder.AppendLine($"Register Date:{RegisterDate.ToShortDateString()}");
            builder.AppendLine($"Has Money{HasMoney}");
            return builder.ToString();
        }
    }
}