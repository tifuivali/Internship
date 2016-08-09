using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi_.Models.Autentification;

namespace HotelApi_.UserManager
{
    public interface IUserManager
    {
        User GetUser(User user);

        void AddUser(RegisterUser user);
    }
}
