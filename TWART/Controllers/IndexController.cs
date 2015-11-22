using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TWART.Controllers
{
    public class IndexController : System.Web.Mvc.Controller
    {

        public ActionResult AdminIndex()
        {
            // Ensures logged in
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ClientIndex()
        {
            // Ensures logged in
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }
        }
	}
}