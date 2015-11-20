using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class DepartmentController : System.Web.Mvc.Controller
    {
        // GET: Department
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
                // Establishes a department model
                DepartmentModel departmentModel = new DepartmentModel();

                // Holds the new department
                Department newDepartment = new Department();

                // Stored details for the department
                newDepartment.Title = Request.Form[1];
                newDepartment.Head = int.Parse(Request.Form[2]);
                newDepartment.Address = int.Parse(Request.Form[3]);

                // Commences save to database
                departmentModel.CreateNewDepartment(newDepartment);

                // Return created department to view
                return View(newDepartment);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        [HttpPost]
        // Controller for modification of a department
        public ActionResult EditDepartment()
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
                // Creates an address placeholder
                var d = new Department();

                // Setup address edit
                d.Id = int.Parse(Request.Form["id"]);
                d.Title = Request.Form["title"];
                d.Head = int.Parse(Request.Form["head"]);
                d.Address = int.Parse(Request.Form["address"]);

                // Establish address model
                var dm = new DepartmentModel();

                // Conduct edit
                dm.EditDepartment(d);

                // TODO: Redirect to appropriate page (Add address?)

                // Passes back to the view
                return View();
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Deletes a department
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
                int departmentID = int.Parse(RouteData.Values["id"].ToString());

                // Establishes department model
                DepartmentModel departmentModel = new DepartmentModel();

                // Deletes the department from the database using the ID
                departmentModel.DeleteDepartment(departmentID);

                // TODO: Confirm this is the correct return state
                // Return to department listing
                return Redirect("../department");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Returns a list of all departments
        public ActionResult Department()
        {
            if (Session["loggedInState"] == null)
            {
                Redirect("403.html");
            }

            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Acquires complete department list
                var dm = new DepartmentModel();
                var dl = dm.GetDepartmentsList();

                // Return list of departments
                return View(dl);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }


    }
}