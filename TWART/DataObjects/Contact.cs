using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Contact
    {
        public int ID { get; set; }
        public String Forename { get; set; }
        public String Surname { get; set; }
        public String Position { get; set; }
        public String PhoneNumber { get; set; }
    }
}