using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;
using TWART.Controllers;

namespace TWART.Controllers
{
    public class LogoutController : System.Web.Mvc.Controller
    {

        // GET: Logout
        [HttpPost]
        public ActionResult Index()
        {  

            doLogout();

            // redirect the user to the index page
            return Redirect("/index.html");
        }

        private bool doLogout()
        {
            // Holds the state of the Logout
            LoggedIn result = null;
            result.State = false;

            // Sets the Session variable
            Session["loggedInState"] = null;
            Session["loggedInUser"] = null;

            // Returns bool. State of the Logout attempt
            return result.State;

        }

    }
}