using System;
using System.Collections.Generic;
using TWART.DataObjects;
using TWART.Models;
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

            // Performs login
            doLogin();
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
            // Holds the state of the login
            LoggedIn result = null;

            if (username != null && password != null)
            {
                // Establishes model for login 
                LoginModel loginControl = new LoginModel();

                // Creates a new user with the specified details
                User newUser = new User();
                newUser.username = username;
                newUser.password = password;

                // Passes the user to the login model
                result = loginControl.Login(newUser);   

                // Returns bool. State of the login attempt
                return result.State;
            }
            else
            {
                // Failure to login
                return false;
            }
        }
    }
}