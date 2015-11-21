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

            // Sets the Session variables
            Session["loggedInState"] = logState.State;
            Session["username"] = thisUser.username;
            Session["userID"] = logState.UserID;

            // Acquire type of user from Ryan
            // Redirect based on user:
                // Admin (Staff)
                // User (Client)
				
            // variable to store the path to redirect to
			String pageToDirectTo = "/index.html";

            try { 
                bool state = (bool)Session["loggedInState"];
                if (state == true)  
                {
                    pageToDirectTo = "/Index/";
                    if (logState.AccessLevel.Equals("Admin"))
                    {
                        pageToDirectTo = "/Index/adminIndex";
                    }
                    else
                    {
                        pageToDirectTo = "/Index/clientIndex";// doesn't work
                    }
                }
                else                              
                {
                    pageToDirectTo = "/login.html";   
                }                  
            }catch(Exception e){
                pageToDirectTo = "/403.html";
            }     

            // redirect the user to the relevant page
            return Redirect(pageToDirectTo);
        }

    }
}