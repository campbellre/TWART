using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    // Handles access to the Address classes for direct database modification (used to create new addresses)
    public class AddressController : System.Web.Mvc.Controller
    {
        // GET: Address
        public ActionResult Index()
        {
            // Ensures logged in
            try
            {
                // Checks if logged in
                bool state = (bool)Session["loggedInState"];
                if (state == true)
                {
                    // Creates an address model
                    AddressModel addressModel = new AddressModel();

                    // Holds the new address
                    Address newAddress = new Address();

                    // Stored details for address
                    newAddress.LineOne = Request.Form[0];
                    newAddress.LineTwo = Request.Form[1];
                    newAddress.LineThree = Request.Form[2];
                    newAddress.LineFour = Request.Form[3];
                    newAddress.LineFive = Request.Form[4];
                    newAddress.State = Request.Form[5];
                    newAddress.County = Request.Form[6];
                    newAddress.Country = Request.Form[7];
                    newAddress.PostalCode = Request.Form[8];

                    // Adds the object to the database
                    addressModel.CreateAddress(newAddress);

                    // Passes back to the view with address
                    return View(newAddress);
                }
                else
                {
                    // If not logged in
                    return Redirect("/login.html");
                }
            }
            catch (Exception e)
            {
                // If an error occurs
                return Redirect("/403.html");
            }
        }

        [HttpPost]
        // Controller for modification of an address
        public ActionResult EditAddress()
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
                // Creates an address placeholder
                var a = new Address();

                // Setup address edit
                a.ID = int.Parse(Request.Form["id"]);
                a.LineOne = Request.Form["lineOne"].ToString();
                a.LineTwo = Request.Form["lineTwo"].ToString();
                a.LineThree = Request.Form["lineThree"].ToString();
                a.LineFour = Request.Form["lineFour"].ToString();
                a.LineFive = Request.Form["lineFive"].ToString();
                a.PostalCode = Request.Form["postalCode"].ToString();
                a.County = Request.Form["county"].ToString();
                a.Country = Request.Form["country"].ToString();

                // Establish address model
                var am = new AddressModel();

                // Conduct edit
                am.EditAddress(a);

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
    }
}