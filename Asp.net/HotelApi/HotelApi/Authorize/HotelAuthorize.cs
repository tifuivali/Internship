using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelApi_.Authorize
{
    public class HotelAuthorize:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            /*
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }
            */
            var user = httpContext.Session["User"];
            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}