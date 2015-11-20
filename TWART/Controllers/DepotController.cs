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
    }
}