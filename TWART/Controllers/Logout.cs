using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWART.DataObjects;
using TWART.Models;
using System.Web.UI;

namespace TWART.Controller
{
    // Handles the Logout to the server / database
    public class Logout
    {
        // Blank constructor
        public Logout() 
        { 
            // Blank constructor    
        }

        /*
         * Handles Logout for the class
         * 
         * @param: 
         * @return: If successful
         */
        public bool doLogout()
        {
            // Holds the state of the Logout
            LoggedIn result = null;
            result.State = false;
            
            // Sets the Session variable
            HttpContext.Current.Session["loggedInState"] = null;
            HttpContext.Current.Session["loggedInUser"] = "";

            // Returns bool. State of the Logout attempt
            return result.State;

        }
    }
}