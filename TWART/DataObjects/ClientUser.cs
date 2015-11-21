using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class ClientUser
    {
        public int UserID { get; set; }
        public int AccountID { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public String Name { get; set; }
    }
}