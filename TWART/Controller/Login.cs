using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.Controller
{
    // Handles the login to the server / database
    public class Login
    {
        // Class parameters
        String username;
        String password;


        // Constructor
        public Login (string username, string password)
        {
            // CONSTRUCTOR GOES HERE
            this.username = username;
            this.password = password;
        }

        // Blank constructor
        public Login() 
        { 
            // Blank constructor    
        }

        /*
         * Handles login for the class
         * 
         * @param: 
         * @return: If successful
         */
        public bool doLogin()
        {
            if (username != null && password != null)
            {
                // return callRyansLogin(username, password);
                return false;
            }
            else
            {
                // Error message
                // Change a text box to display error message (Tousif - UI)
                return false;
            }
        }
    }
}