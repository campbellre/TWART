using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class RoleController : System.Web.Mvc.Controller
    {
        // GET: Role
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
                // Establishes role model
                RoleModel roleModel = new RoleModel();

                // Holds the new role
                Role newRole = new Role();

                // Stored details for the role
                newRole.Title = Request.Form[0];

                // Adds the object to the database
                roleModel.CreateRole(newRole);

                // Returns the created role to view
                return View(newRole);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Controller for modification of a role
        public ActionResult EditRole()
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
                // Creates a role placeholder
                var role = new Role();

                // Setup role edit
                role.Id = int.Parse(Request.Form["id"]);
                role.Title = Request.Form["title"];

                // Establishes role model
                var roleModel = new RoleModel();

                // Conduct edit
                roleModel.EditRole(role);

                // Passes back to the view
                return View();
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Deletes a role
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
                int roleID = int.Parse(RouteData.Values[""].ToString());

                // Establishes role model
                RoleModel roleModel = new RoleModel();

                // Deletes the role from the database using the ID
                roleModel.DeleteRole(roleID);

                return Redirect("/..role");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Lists all roles
        public ActionResult ListRoles()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Creates an employee model
                var rm = new RoleModel();

                // Gets the complete list
                var rl = rm.ListRoles();

                // Returns the list
                return View(rl);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
    }
}