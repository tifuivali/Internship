using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HotelApi_.Models.Autentification;

namespace HotelApi_.UserManager
{
    public class UserManagerDb:IUserManager
    {
        private static UserManagerDb userManagerDb;

        private static SqlConnection connection;

        private UserManagerDb()
        {
            connection =
                new SqlConnection(
                    "Data Source = IASI - H5BP4G7; Initial Catalog = Users; User ID = sa; Password = 1234 % asd");
            connection.Open();
        }


        public User GetUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}