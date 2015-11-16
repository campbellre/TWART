using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.Controller
{
    // Handles the registration process of the web
    public class Register
    {
        String username;
        String email;
        String companyName;
        String password;
        String checkPass;

        // Primary constructor for Register
        public Register(String username, String email, String companyName, String password, String checkPass)
        {
            this.username = username;
            this.email = email;
            this.companyName = companyName;
            this.password = password;
            this.checkPass = checkPass;

            // Performs registration
            doRegistration();
        }

        // Blank constructor
        public Register()
        {}

        // Perform registration
        private bool doRegistration()
        {
            // To handle the registration to the database
            Login registerControl = new Login();

            try
            {
                // 
            }
            catch
            {

            }

            return true;
        }
    }
}