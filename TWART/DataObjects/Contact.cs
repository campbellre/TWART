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

        // Constructor for Contact
        public Contact(int ID, String forename, String surname, String position, String phoneNumber)
        {
            this.ID = ID;
            this.Forename = forename;
            this.Surname = surname;
            this.Position = position;
            this.PhoneNumber = phoneNumber;
        }
    }
}