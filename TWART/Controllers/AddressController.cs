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

                    // Passes back to the view
                    return View();
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

        // Controller for modification of an address
        public ActionResult Edit()
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

                    // Gets the ID as a parameter
                    var p = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

                    // 

                    // Passes back to the view
                    return View();
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
    }
}