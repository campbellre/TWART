using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class DepotController : System.Web.Mvc.Controller
    {
        // GET: Depot
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
                // Establishes depot model
                DepotModel depotModel = new DepotModel();

                // Holds the new depot
                Depot newDepot = new Depot();

                // Stored details for the depot
                newDepot.AddressID = int.Parse(Request.Form[0]);
                newDepot.ManagerID = int.Parse(Request.Form[1]);
                newDepot.DepotName = Request.Form[2];
                newDepot.FloorSpace = Double.Parse(Request.Form[3]);
                newDepot.NumVehicles = int.Parse(Request.Form[4]);

                // Adds the object to the database
                depotModel.CreateDepot(newDepot);

                // Return created department to view
                return View(newDepot);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Controller for modification of a depot
        public ActionResult EditDepot()
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
                var depot = new Depot();

                // Setup role edit
                depot.ID = int.Parse(Request.Form["id"]);
                depot.ManagerID = int.Parse(Request.Form["managerID"]);
                depot.DepotName = Request.Form["depotName"];
                depot.FloorSpace = int.Parse(Request.Form["floorSpace"]);
                depot.NumVehicles = int.Parse(Request.Form["numVehicles"]);

                // Establishes role model
                var depotModel = new DepotModel();

                // Conduct edit
                depotModel.EditDepot(depot);

                // Passes back to the view
                return View();
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Deletes a depot
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
                int depotID = int.Parse(RouteData.Values[""].ToString());

                // Establishes role model
                DepotModel depotModel = new DepotModel();

                // Deletes the depot from the database using the ID
                depotModel.DeleteDepot(depotID);

                return Redirect("/..depot");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
    }
}