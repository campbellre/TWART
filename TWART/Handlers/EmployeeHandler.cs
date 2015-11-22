using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Handlers
{
    public class EmployeeHandler
    {
        // Constructor
        public EmployeeHandler()
        { }

        // Create employee
        public int create(String firstname, String lastname, DateTime DOB, String contactNum,
                          DateTime startDate, int dept, int depot, int role)
        {
            // Establishes model
            EmployeeModel employeeModel = new EmployeeModel();

            // Holds the new employee
            Employee newEmployee = new Employee();

            // Stored details for the employee
            newEmployee.Firstname = firstname;
            newEmployee.Lastname = lastname;
            newEmployee.DOB = DOB;
            newEmployee.ContactNumber = contactNum;
            newEmployee.Startdate = startDate;
            newEmployee.Dept = dept;
            newEmployee.Depot = depot;
            newEmployee.Role = role;

            // Adds the object to the database
            int employeeID = employeeModel.NewEmployee(newEmployee);

            // Return the employeeID
            return employeeID;
        }
    }
}