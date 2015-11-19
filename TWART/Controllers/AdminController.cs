using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class AdminController : System.Web.Mvc.Controller
    {

		// Function to get a list of all customers
        public ActionResult Customer()
        {
		
			 // Create a new AddressModel object
			var addressModel = new AddressModel();
			
			// Create a CustomerModel object
            var cm = new CustomerModel();

			// Call the method to get the list
            var cl = cm.ListCustomers();
			
			
			foreach (var c in cl){
				Address address = addressModel.SearchAddress(c.Address_ID);
				c.Address = address;
			}
			
			// Return the CustomerList
            return View(cl);
        }

		
		// Function to do something
        public ActionResult Edit()
        {

			// Get the ID as a parameter
            var p = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

			// Create a new CustomerModel object
            var cm = new CustomerModel();

			// Call the method to search for a Customer with an ID matching the value passed in
            var c = cm.SearchCustomers(p);

			// Return the Customer information
            return View(c);

        }



        [HttpPost]
        public ActionResult EditCustomer()
        {
            var c = new Customer();
            c.ID = int.Parse(Request.Form["id"]);
            c.Name = Request.Form["name"].ToString();
            c.Address_ID = int.Parse(Request.Form["addressid"]);

            var cm = new CustomerModel();

            cm.EditCustomer(c);

            // TODO: This Should be dynamic. Not go to '1' all the time.
            return Redirect("/Admin/Edit/1");

        }

    }
}