using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HotelApi_.Models.Autentification;

namespace HotelApi_.UserManager
{
    public class UserManagerDb : IUserManager
    {
        private static UserManagerDb userManagerDb;

        private static SqlConnection connection;

        private UserManagerDb()
        {
            connection =
                new SqlConnection(
                    "Data Source =IASI-H5BP4G7;Initial Catalog=Users;User ID=sa;Password=1234%asd");
            connection.Open();
        }

        public static UserManagerDb GetInstance()
        {
            if (userManagerDb == null)
                userManagerDb = new UserManagerDb();
            return userManagerDb;
        }

        public bool AddUser(RegisterUser user)
        {
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select count(*) from Users where UserName=@userName";
            var userNameParam=new SqlParameter("@userName",user.UserName);
            cmd.Parameters.Add(userNameParam);
            var nrUsers = (int) cmd.ExecuteScalar();
            if (nrUsers > 0)
                return false;
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "insert into Users values (@userName,@password)";
            cmd.Parameters.AddRange(GetUserSqlParams(user));
            cmd.ExecuteNonQuery();
            return true;
        }

        private SqlParameter[] GetUserSqlParams(User user)
        {
            var userNameParam = new SqlParameter("@userName", user.UserName);
            var passwordParam = new SqlParameter("@password", user.Password);
            return new[] {userNameParam, passwordParam};
        }

        public User GetUser(User user)
        {
            User userCheck = null;
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText =
                "select top 1 * from Users where UserName=@userName and Password = @password";
          
            cmd.Parameters.AddRange(GetUserSqlParams(user));
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    userCheck = new User();
                    userCheck.UserName = (string)reader["UserName"];
                    userCheck.Password = (string)reader["Password"];
                    userCheck.RememberMe = true;
                    userCheck.UserId = (int)reader["Id"];
                }


            }
            return userCheck;
        }
    }
}