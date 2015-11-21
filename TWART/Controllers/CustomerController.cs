using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.Models;
using TWART.DataObjects;

namespace TWART.Controllers
{
    public class CustomerController : System.Web.Mvc.Controller
    {
        public ActionResult EditCustomer()
        {
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                var c = new Customer();
                c.ID = int.Parse(Request.Form["id"]);
                c.Name = Request.Form["name"].ToString();
                c.Address_ID = int.Parse(Request.Form["addressid"]);
                var cm = new CustomerModel();
                cm.EditCustomer(c);
                return Redirect("Customer");
            }
        }


    //    // Allows modification of customer
    //    public ActionResult viewInfo()
    //    {
    //        //If there is no valid session, return forbidden
    //        if (Session["loggedInState"] == null)
    //        {
    //            return Redirect("/403.html");
    //        }
    //        else
    //        {
    //            // Create a new AddressModel object
    //            var addressModel = new AddressModel();
    //            // Create a CustomerModel object
    //            var customerModel = new CustomerModel();
    //            // Call the method to get the list
    //            var customerList = customerModel.ListCustomers();

    //            // Get the ID requested
    //            var p = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

    //            foreach (var customer in customerList)
    //            {
    //                if (customer.ID == p)
    //                {
    //                    Address address = addressModel.SearchAddress(customer.Address_ID);
    //                    customer.Address = address;

    //                    return View(customer);
    //                }
    //            }
    //            // No match found! Change the page later...
    //            return Redirect("/404.html");
    //        }
        
    //    }

    //    public ActionResult edit()
    //    {
    //        //If there is no valid session, return forbidden
    //        if (Session["loggedInState"] == null)
    //        {
    //            return Redirect("/403.html");
    //        }
    //        else
    //        {
    //            // Create a new AddressModel object
    //            var addressModel = new AddressModel();
    //            // Create a CustomerModel object
    //            var customerModel = new CustomerModel();
    //            // Call the method to get the list
    //            var customerList = customerModel.ListCustomers();

    //            // Get the ID requested
    //            var p = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

    //            foreach (var customer in customerList)
    //            {
    //                if (customer.ID == p)
    //                {
    //                    Address address = addressModel.SearchAddress(customer.Address_ID);
    //                    customer.Address = address;

    //                    return View(customer);
    //                }
    //            }
    //            // No match found! Change the page later...
    //            return Redirect("/404.html");
    //        }

    //    }


    //    // Allows deleting of customer
    //    public ActionResult Delete()
    //    {
    //        // Null handling
    //        if (Session["loggedInState"] == null)
    //        {
    //            return Redirect("/403.html");
    //        }

    //        // Checks if logged in
    //        bool state = (bool)Session["loggedInState"];
    //        if (state == true)
    //        {
    //            int customerID = int.Parse(RouteData.Values["id"].ToString());

    //            // Establishes account model
    //            CustomerModel customerModel = new CustomerModel();                            

    //            // Deletes the account, and contact from the database using the ID
    //            customerModel.DeleteCustomer(customerID);
                

    //            // TODO: Confirm this is the correct return state
    //            // Return to the account page
    //            return Redirect("/Customer/deleteCustomers");
    //        }
    //        else
    //        {
    //            // If not logged in
    //            return Redirect("/login.html");
    //        }
    //    }

    }
}