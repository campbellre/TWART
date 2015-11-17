using System;
using System.Collections.Generic;
using TWART.DataObjects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TWART.Controller
{
    public class LoginController : System.Web.Mvc.Controller
    {
        // GET: Login
        public ActionResult Index()
        {  
            // To store login details
            String username;
            String password;

            // Acquire login details from front-end
            username = Request.QueryString["username"];
            password = Request.QueryString["password"];

            // Composes object
            User thisUser = new User();
            thisUser.username = username;
            thisUser.password = password;

            // Acquire type of user from Ryan
            // Redirect based on user:
                // Admin (Staff)
                // User (Client)
            // End


            return Redirect("/index.html");
        }
    }
}