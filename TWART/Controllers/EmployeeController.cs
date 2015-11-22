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
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Establishes employee model
                EmployeeModel employeeModel = new EmployeeModel();

                // Holds the new employee
                Employee newEmployee = new Employee();

                // Stored details for the employee
                newEmployee.Firstname = Request.Form[0];
                newEmployee.Lastname = Request.Form[1];
                newEmployee.DOB = DateTime.Parse(Request.Form[2]);
                newEmployee.ContactNumber = Request.Form[3];
                newEmployee.Startdate = DateTime.Parse(Request.Form[4]);
                newEmployee.Dept = int.Parse(Request.Form[5]);
                newEmployee.Depot = int.Parse(Request.Form[6]);
                newEmployee.Role = int.Parse(Request.Form[7]);

                // Adds the object to the database
                employeeModel.NewEmployee(newEmployee);

                // Return created employee to view
                return View(newEmployee);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Controller to redirect to the edit page - ANDREW DID THIS - TRISTAN FIXED THIS
        public ActionResult edit()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Get the employee ID
                int employeeID = int.Parse(RouteData.Values["id"].ToString());

                // Create a new EmployeeModel
                EmployeeModel employeeModel = new EmployeeModel();

                // Finds employee
                Employee employee = employeeModel.SearchEmployee(employeeID);

                // Return employee to view
                return View(employee);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }



        // Controller for modification of an employee
        public ActionResult EditEmployee()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Creates an employee placeholder
                var employee = new Employee();

                // Setup employee edit
                employee.Id = int.Parse(Request.Form["id"]);
                employee.Firstname = Request.Form["firstname"];
                employee.Lastname = Request.Form["lastname"];
                employee.DOB = DateTime.Parse(Request.Form["DOB"]);
                employee.ContactNumber = Request.Form["contactNum"];
                employee.Startdate = DateTime.Parse(Request.Form["startDate"]);
                employee.Dept = int.Parse(Request.Form["depart"]);
                employee.Depot = int.Parse(Request.Form["depot"]);
                employee.Role = int.Parse(Request.Form["role"]);

                // Establish an employee model
                var employeeModel = new EmployeeModel();

                // Conduct edit
                employeeModel.EditEmployee(employee);

                // Passes back to the view
                return Redirect("Employee/Employee");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Deletes an employee
        public ActionResult Delete()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                int employeeID = int.Parse(RouteData.Values["id"].ToString());

                // Establishes employee model
                EmployeeModel employeeModel = new EmployeeModel();

                // Deletes the employee from the database using the ID
                employeeModel.DeleteEmployee(employeeID);

                // Return to the employee page
                return Redirect("/Employee/Employees");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Returns a complete list of employees
        public ActionResult Employees()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // If logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Creates models
                var employeeModel = new EmployeeModel();
                var departmentModel = new DepartmentModel();
                var roleModel = new RoleModel();
                var depotModel = new DepotModel();

                // Gets the complete list
                List<Employee> el = employeeModel.GetEmployeesList();

                if (el.Count != 0)
                {
                    // Attaches associated department / role to employee
                    foreach (var employee in el)
                    {
                        // Acquires, and adds the employee depot
                        Depot depot = null;
                        if (employee.Depot != 0)
                        {
                            depot = depotModel.SearchDepot(employee.Depot);
                        }

                        // Acquires, and adds the employee department
                        Department dept = null;
                        if (employee.Dept != 0)
                        {
                            dept = departmentModel.SearchDepartment(employee.Dept);
                        }

                        // Acquires, and adds the employee role
                        Role role = null;
                        if (employee.Role != 0)
                        {
                            role = roleModel.SearchRoles(employee.Role);
                        }

                        // Appends objects to employee
                        employee.DepotO = depot;
                        employee.Department = dept;
                        employee.RoleO = role;
                    }

                    // Returns the list
                    return View(el);
                }
                else
                {
                    return Redirect("/403.html");
                }
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
    }
}