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
                userManager.AddUser(tempUser);

                return RedirectToAction("Login", "Login");
            }
            return View();

        }
    }
}