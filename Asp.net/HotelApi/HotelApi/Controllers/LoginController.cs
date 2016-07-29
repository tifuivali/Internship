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
        private UserManager.UserManager userManager;

        public LoginController()
        {
            userManager = UserManager.UserManager.GetInstace();
            userManager.Populate();
        }


        // GET: Login
        public ActionResult Login()
        {
            if (Session["User"] != null)
                return Redirect("Hotel/Index");
            return View();
        }

        [HttpPost]
        public ActionResult Login(User tempUserName, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.GetUser(tempUserName);
                if (user != null)
                {
                    Session["User"] = user;
                    FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return Redirect(returnUrl);
                }
                ModelState.AddModelError("", "Log in failed.");
            }
            else
            {
                ModelState.AddModelError("", "Log in failed.");

            }
            return View();
        }




    }
}