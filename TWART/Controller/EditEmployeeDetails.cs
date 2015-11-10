using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.Controller
{
    // Handles the login to the server / database
    public class EditEmployeeDetails
    {
        // Class parameters - THERE'S PROBABLY MORE
        int employeeId;
        String contactNumber;
        String firstName;
        String surname;
        Date DOB;
        Date start_Date;
        Date end_Date;
        int depot_id;
        int role_id;


        // Constructor
        public EditEmployeeDetails (int ID, String contact, String fN, String sN, Date bDate, Date sDate, Date eDate, int depot, int role)
        {
            // CONSTRUCTOR GOES HERE
            this.employeeId = ID;
            this.contactNumber = tele;
            this.firstName = fN;
            this.surname = sN;
            this.DOB = bDate;
            this.start_date = sDate;
            this.end_date = eDate;
            this.depot_id = depot;
            this.role_id = role;

        }

        // Blank constructor
        public EditEmployeeDetails() 
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
            //return ryansMethod(this.contactId, this.telephone, this.firstName, this.surname);
            return false;
        }
    }
}