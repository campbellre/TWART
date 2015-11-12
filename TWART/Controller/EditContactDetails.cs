using System;
using System.Collections.Generic;
using TWART.DataObjects;
using System.Linq;
using System.Web;

namespace TWART.Controller
{
    // Handles the login to the server / database
    public class EditContactDetails
    {
        // Class parameters - THERE'S PROBABLY MORE
        int contactId;
        String telephone;
        String firstName;
        String surname;
        String position;


        // Constructor
        public EditContactDetails (int ID, String tele, String fN, String sN, String pos)
        {
            // CONSTRUCTOR GOES HERE
            this.contactId = ID;
            this.telephone = tele;
            this.firstName = fN;
            this.surname = sN;
            this.position = pos;
        }

        // Blank constructor
        public EditContactDetails() 
        { 
            // Blank constructor    
        }

        /*
         * Handles the process to edit details for a user
         * 
         * @param: 
         * @return: If successful
         */
        public bool saveDetails()
        {
            // Contact newContact = new Contact(contactId, firstName, surname, position, telephone);
            // return ryansMethod(newContact);
            return false;
        }
    }
}