using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApi_.Models.Autentification;

namespace HotelApi_.UserManager
{
    public class UserManagerList:IUserManager
    {
        private static UserManagerList instance;

        private List<User> users;

        public List<User> Users => users.ToList();

        private UserManagerList()
        {
            users = new List<User>();
        }

        public static UserManagerList GetInstace()
        {
            return instance ?? (instance = new UserManagerList());
        }

        public User GetUser(User user)
        {
            return users.FirstOrDefault(u => u.UserName == user.UserName & u.Password == user.Password);
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void Populate()
        {
            users.Add(new User() {UserId = 1,Password = "vali",UserName = "vali"});
            users.Add(new User() {UserId = 2,Password = "ion",UserName = "ion"});
        }
    }
}