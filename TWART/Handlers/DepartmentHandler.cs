using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Handlers
{
    public class DepartmentHandler
    {
        // Constructor
        public DepartmentHandler()
        { }

        // Create new department
        public int create(int address, String title)
        {
            // Establishes models
            DepartmentModel deptModel = new DepartmentModel();

            // Holds new department details
            Department newDept = new Department();

            // Stored details for the department
            newDept.AddressID = address;
            newDept.Title = title;

            // Creates the department
            int deptID = deptModel.CreateNewDepartment(newDept);

            // Returns departmentId
            return deptID;
        }
    }
}