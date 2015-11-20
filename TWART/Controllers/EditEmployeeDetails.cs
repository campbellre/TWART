using System;
using System.Collections.Generic;
using TWART.DataObjects;
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
        DateTime DOB;
        DateTime startDate;
        DateTime endDate;
        int depot_id;
        int dept_id;
        int role_id;


        // Constructor
        public EditEmployeeDetails(int ID, String contact, String fN, String sN, DateTime bDate, DateTime sDate, DateTime eDate, int depot, int dept, int role)
        {
            // CONSTRUCTOR GOES HERE
            this.employeeId = ID;
            this.contactNumber = contact;
            this.firstName = fN;
            this.surname = sN;
            this.DOB = bDate;
            this.startDate = sDate;
            this.endDate = eDate;
            this.depot_id = depot;
            this.dept_id = dept;
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
            Employee newEmployee = new Employee();
            newEmployee.Id = employeeId;
            newEmployee.Firstname = firstName;
            newEmployee.Lastname = surname;
            newEmployee.DOB = DOB;
            newEmployee.ContactNumber = contactNumber;
            newEmployee.Startdate = startDate;
            newEmployee.Dept = dept_id;
            newEmployee.Depot = depot_id;
            newEmployee.Role = role_id;
            //return ryansMethod(newEmployee);
            return false;
        }
    }
}