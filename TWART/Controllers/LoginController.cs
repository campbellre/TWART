﻿using System;
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

        [HttpGet]
        public ActionResult Index()
        {
            return Redirect("/index.html");
        }

        // GET: Login
        [HttpPost]
        public ActionResult loginpost()
        {  

            LoginModel loginModel = new LoginModel();

            // To store login details
            String username;
            String password;

            // Acquire login details from front-end
            username = Request.Form[0];
            password = Request.Form[1];

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
                    pageToDirectTo = "/403.html";     // this will change to the standard login page
                    //note by will: this will instead show a forbidden access page
                }
            }                                   
            else                              
            {                                 
                pageToDirectTo = "/index.html";   
            }                                    

            // redirect the user to the relevant page
            return Redirect(pageToDirectTo);
        }

    }
}