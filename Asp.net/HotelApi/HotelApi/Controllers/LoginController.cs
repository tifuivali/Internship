using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HotelApi_.Models.Autentification;
using Microsoft.Owin.Security.Provider;

namespace HotelApi_.Controllers
{
    public class LoginController : Controller
    {
        private UserManager.IUserManager _userManager;

        public LoginController()
        {
            _userManager = UserManager.UserManagerDb.GetInstance();
            
        }


        // GET: Login
        public ActionResult Login()
        {
            if (Session["User"] != null)
                return RedirectToAction("Index","Hotel");
            return View();
        }

        [HttpPost]
        public ActionResult Login(User tempUserName, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetUser(tempUserName);
                if (user != null)
                {
                    Session["User"] = user;
                    FormsAuthentication.SetAuthCookie(user.UserName, tempUserName.RememberMe);
                    return Redirect(returnUrl);
                }
                ModelState.AddModelError("", "Incorect username or password.");
            }
            else
            {
                ModelState.AddModelError("", "Log in failed.");

            }
            return View();
        }




    }
}