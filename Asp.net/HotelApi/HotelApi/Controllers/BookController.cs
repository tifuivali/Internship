using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApi_.Authorize;

namespace HotelApi_.Controllers
{
    [HotelAuthorize]
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Book()
        {
            return View();
        }
    }
}