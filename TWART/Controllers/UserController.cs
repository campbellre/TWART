using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.Models;
using TWART.DataObjects;

namespace TWART.Controllers
{
    public class UserController : System.Web.Mvc.Controller
    {
        // Creates a new client user
        public ActionResult CreateClient()
        {
            // Ensures logged in
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Establishe client model
                var cModel = new ClientUserModel();

                // Holds new client
                ClientUser newClient = new ClientUser();

                // Acquires needed Account ID
                int accountID = int.Parse(Request.Form["accountID"]);

                // Stored details for the customer
                newClient.Name = Request.Form["clientName"];
                
                // Creates the customer
                cModel.CreateClientUser(newClient);

                // Return created department to view
                return View(newClient);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Creates a new employee user
        public ActionResult CreateEmployee()
        {
            // Ensures logged in
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Establishes employee model
                LoginModel eModel = new LoginModel();

                // Holds new client
                User newUser = new User();

                // Stored details for the customer
                newUser.username = Request.Form["username"];
                newUser.password = Request.Form["password"];
                newUser.email = Request.Form["email"];
                newUser.AccessLevel = Request.Form["accessLevel"];

                // Creates the user
                eModel.CreateUser(newUser);

                // Return created department to view
                return View(newUser);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Deletes a User
    }
}