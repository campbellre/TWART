using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class EmployeeController : System.Web.Mvc.Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            // Ensures logged in
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Establishes employee model
                EmployeesModel employeeModel = new EmployeesModel();

                // Holds the new employee
                Employee newEmployee = new Employee();

                // Stored details for the employee
                


                // Return created department to view
                return View();
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
    }
}