using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class LoggedIn
    {
        // Why State, Why not State
        // TODO: Correct this
        public Boolean State { get; set; }
        public String AccessLevel { get; set; }

        public int UserID { get; set; }

        public Boolean IsLoggedIn()
        {
            return State;
        }

        // Same object of both client and employee 
        // cause why not 
        public int AccountID { get; set; }
    }
}