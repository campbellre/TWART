using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;

namespace TWART.Controllers
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

 
            // get Account Type / Access levels from Database
            //Account_Type accountType = RYANSMETHOD();  ** CODE **

            // Acquire type of user from Ryan
            // Redirect based on user:
                // Admin (Staff)
                // User (Client)
				
            // variable to store the path to redirect to
			String pageToDirectTo = "/index.html";

            // if the user is an admin, go to the admin page
            //if (accountTypeName.equals("Admin"))  ** CODE **
            //{                                     ** CODE **
                pageToDirectTo = "/admin.aspx";
            //}                                     ** CODE **

            // otherwise, go to the main login page
                //else                              ** CODE **
                //{                                 ** CODE **
                // THIS WILL CHANGE ONCE THE OTHER PAGE HAS BEEN CREATED
                //pageToDirectTo = "/admin.aspx";   ** CODE **
            //}                                     ** CODE **

            // redirect the user to the relevant page
            return Redirect(pageToDirectTo);
        }

               // GET: Login
        public string Test()
        {
            return "BANANA HAMMOCK";
        }

    }
}