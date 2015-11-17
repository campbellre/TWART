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

 
            // getAccount Type from Database
            // Account_Type accountType = RYANSMETHOD();  ** CODE **

            // Acquire type of user from Ryan
            // Redirect based on user:
                // Admin (Staff)
                // User (Client)
				
            // variable to store the path to redirect to
			String pageToDirectTo = "/index.html";

            // if the user is an admin, go to the admin page
            if (accountTypeName.equals("Admin"))
            {
                pageToDirectTo = "/admin.aspx";
            }

            // otherwise, go to the main login page
            else 
            {
                // THIS WILL CHANGE ONCE THE OTHER PAGE HAS BEEN CREATED
                pageToDirectTo = "/admin.aspx";
            }

            // redirect the user to the relevant page
            return Redirect(pageToDirectTo);
        }
    }
}