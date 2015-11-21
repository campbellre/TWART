using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class User
    {
        public int ID { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public String AccessLevel { get; set; }
    }
}