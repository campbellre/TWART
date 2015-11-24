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
        [HttpPost]
        public ActionResult loginpost()
        {  

            LoginModel loginModel = new LoginModel();
            ClientUserModel clientmModel = new ClientUserModel();
            
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
            ClientUser client = new ClientUser();
            client.Username = username;
            client.Password = password;

 
            // get Account Type / Access levels from Database
            LoggedIn logState;
            logState = loginModel.Login(thisUser);

            if (logState.State)
            {
                Session["loggedInState"] = logState.State;
                Session["username"] = thisUser.username;
                Session["userID"] = logState.UserID;
                Session["Type"] = "Employee";
            }
            else
            {
                logState = clientmModel.Login(client);

                Session["loggedInState"] = logState.State;
                Session["username"] = client.Username;
                Session["userID"] = logState.UserID;
                Session["Type"] = "Client";
            }

            // Sets the Session variables


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
                    if (Session["Type"] == "Employee")
                    {
                        pageToDirectTo = "/Index/";
                        if (logState.AccessLevel.Equals("Admin"))
                        {
                            pageToDirectTo = "/Index/adminIndex";
                        }
                    }
                    else
                    {
                        pageToDirectTo = "/Index/clientIndex"; // doesn't work
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