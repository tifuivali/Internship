using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApi_.Authorize;

namespace HotelApi_.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        [HotelAuthorize]
        public ActionResult Index()
        {
            return View("Hotel");
        }
    }
}