using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelApi_.Models.Autentification;

namespace HotelApi_.UserManager
{
    public class UserManager
    {
        private static UserManager instance;

        private List<User> users;

        public List<User> Users => users.ToList();

        private UserManager()
        {
            users = new List<User>();
        }

        public static UserManager GetInstace()
        {
            return instance ?? (instance = new UserManager());
        }

        public User GetUser(User user)
        {
            return users.FirstOrDefault(u => u.UserName == user.UserName & u.Password == user.Password);
        }

        public void Populate()
        {
            users.Add(new User() {UserId = 1,Password = "vali",UserName = "vali"});
            users.Add(new User() {UserId = 2,Password = "ion",UserName = "ion"});
        }
    }
}