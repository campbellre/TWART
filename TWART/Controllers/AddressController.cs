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
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

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

                // Adds the object to the database. Returns address ID
                int addressID = addressModel.CreateAddress(newAddress);

                // Append ID to address object
                newAddress.ID = addressID;

                // Passes back to the view with address
                return View(newAddress);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
        // Controller for modification of an address
        public ActionResult EditAddress()
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
                var address = new Address();

                // Setup address edit
                address.ID = int.Parse(Request.Form["id"]);
                address.LineOne = Request.Form["lineOne"].ToString();
                address.LineTwo = Request.Form["lineTwo"].ToString();
                address.LineThree = Request.Form["lineThree"].ToString();
                address.LineFour = Request.Form["lineFour"].ToString();
                address.LineFive = Request.Form["lineFive"].ToString();
                address.PostalCode = Request.Form["postalCode"].ToString();
                address.County = Request.Form["county"].ToString();
                address.Country = Request.Form["country"].ToString();

                // Establish address model
                var addressModel = new AddressModel();

                // Conduct edit
                addressModel.EditAddress(address);

                // Passes back to the view
                return View();
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Deletes an address
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

                int addressID = int.Parse(RouteData.Values["id"].ToString());

                // Establishes address model
                AddressModel addressModel = new AddressModel();

                // Deletes the address from the database using the ID
                addressModel.DeleteAddress(addressID);

                // TODO: Confirm this is the correct return state
                // Return to address page
                return Redirect("../address");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        public ActionResult Address()
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
                // Creates an address model
                AddressModel addressModel = new AddressModel();

                // Holds the new address
                List<Address> addressList = addressModel.GetAddressesList();


                // Passes back to the view with address
                return View(addressList);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        public ActionResult ViewAddress()
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
                // Creates an address model
                AddressModel addressModel = new AddressModel();

                // Get the ID as a parameter
                var id = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

                // Holds the new address
                Address theAddress = addressModel.SearchAddress(id);

                // Passes back to the view with address
                return View(theAddress);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

    }

}