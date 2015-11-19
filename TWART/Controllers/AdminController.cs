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

            try
            {
                bool state = (bool)Session["loggedInState"];
                if (state != true)
                {

                    // Create a new AddressModel object
                    var addressModel = new AddressModel();

                    // Create a CustomerModel object
                    var cm = new CustomerModel();

                    // Call the method to get the list
                    var cl = cm.ListCustomers();


                    foreach (var c in cl)
                    {
                        Address address = addressModel.SearchAddress(c.Address_ID);
                        c.Address = address;
                    }

                    // Return the CustomerList
                    return View(cl);
                }
                else
                {
                    return Redirect("/403.html");
                }
            }
            catch (Exception e)
            {
                return Redirect("/403.html");
            }
        }

		
		// Function to do something
        public ActionResult Edit()
        {
            try
            {
                bool state = (bool)Session["loggedInState"];
                if (state != true)
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
                else
                {
                    return Redirect("/403.html");
                }
            }
            catch (Exception e)
            {
                return Redirect("/403.html");
            } 
        }

        public ActionResult Index()
        {
            return Redirect("/Admin/adminIndex");
        }

        public ActionResult adminIndex() {
            return View();
        }

        [HttpPost]
        public ActionResult EditCustomer()
        {
            try
            {
                bool state = (bool)Session["loggedInState"];
                if (state != true)
                {
                    var c = new Customer();
                    c.ID = int.Parse(Request.Form["id"]);
                    c.Name = Request.Form["name"].ToString();
                    c.Address_ID = int.Parse(Request.Form["addressid"]);

                    var cm = new CustomerModel();

                    cm.EditCustomer(c);

                    return Redirect("/Admin/Edit/" + c.ID);
                }
                else
                {
                    return Redirect("/403.html");
                }
            }
            catch (Exception e)
            {
                return Redirect("/403.html");
            }

        }

        
        
        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult ViewInfo()
        {
            return View();
        }

    }
}