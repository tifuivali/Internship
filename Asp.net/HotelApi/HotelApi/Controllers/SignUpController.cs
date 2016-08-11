using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApi_.Models.Autentification;
using HotelApi_.UserManager;

namespace HotelApi_.Controllers
{
    public class SignUpController : Controller
    {
        private IUserManager userManager;
        // GET: SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(RegisterUser tempUser)
        {
            if (ModelState.IsValid)
            {
                userManager = UserManagerDb.GetInstance();
                if (userManager.AddUser(tempUser))
                {
                    return RedirectToAction("Login", "Login");
                }
                ModelState.AddModelError("","Username already exists! Please choose another user name!");
            }
            return View();

        }
    }
}