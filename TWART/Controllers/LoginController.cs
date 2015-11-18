using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class LoginController : System.Web.Mvc.Controller
    {
        // GET: Login
        public ActionResult Index()
        {  

            LoginModel loginModel = new LoginModel();

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
            LoggedIn logState = loginModel.Login(thisUser);

            // Acquire type of user from Ryan
            // Redirect based on user:
                // Admin (Staff)
                // User (Client)
				
            // variable to store the path to redirect to
			String pageToDirectTo = "/index.html";



            if (logState.IsLoggedIn())  
            {
                if (logState.AccessLevel.Equals("Admin"))
                {
                    pageToDirectTo = "/admin.aspx";
                }
                else
                {
                    pageToDirectTo = "/admin.aspx";     // this will change to the standard login page
                }
            }                                   
            else                              
            {                                 
                pageToDirectTo = "/index.aspx";   
            }                                    

            // redirect the user to the relevant page
            return Redirect(pageToDirectTo);
        }

    }
}