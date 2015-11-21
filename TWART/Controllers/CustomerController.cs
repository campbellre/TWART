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
        // GET: Customer
        public ActionResult Customer()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // If logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Creates models
                var addressModel = new AddressModel();
                var customerModel = new CustomerModel();

                // Gets the complete list
                var customerList = customerModel.ListCustomers();

                // Attaches associated address to customer
                foreach (var customer in customerList)
                {
                    Address address = null;
                    if (customer.Address_ID != 0)
                    {
                        address = addressModel.SearchAddress(customer.Address_ID);
                    }

                    // Appends object to address
                    customer.Address = address;
                }

                // Return the CustomerList
                return View(customerList);
            }
            else
            {
                return Redirect("/403.html");
            }
        }


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

        // Creates a new customer
        public ActionResult Create()
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
                // Establishes models
                CustomerModel customerModel = new CustomerModel();
                AddressModel addressModel = new AddressModel();

                // Holds object placeholders
                Customer newCustomer = new Customer();
                
                // Acquires needed addressID
                int addressID = int.Parse(Request.Form["addressID"]);

                // Stored details for the customer
                newCustomer.Name = Request.Form[0];
                newCustomer.Address_ID = addressID;
                newCustomer.Account_ID = int.Parse(Request.Form[1]);
                
                // Creates the customer
                customerModel.CreateCustomer(newCustomer);

                // Return created department to view
                return View(newCustomer);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Allows modification of customer
        public ActionResult viewInfo()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                // Create a new AddressModel object
                var addressModel = new AddressModel();
                // Create a CustomerModel object
                var customerModel = new CustomerModel();
                // Call the method to get the list
                var customerList = customerModel.ListCustomers();

                // Get the ID requested
                var p = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

                foreach (var customer in customerList)
                {
                    if (customer.ID == p)
                    {
                        Address address = addressModel.SearchAddress(customer.Address_ID);
                        customer.Address = address;

                        return View(customer);
                    }
                }
                // No match found! Change the page later...
                return Redirect("/404.html");
            }
        
        }

        public ActionResult edit()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                // Create a new AddressModel object
                var addressModel = new AddressModel();
                // Create a CustomerModel object
                var customerModel = new CustomerModel();
                // Call the method to get the list
                var customerList = customerModel.ListCustomers();

                // Get the ID requested
                var p = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

                foreach (var customer in customerList)
                {
                    if (customer.ID == p)
                    {
                        Address address = addressModel.SearchAddress(customer.Address_ID);
                        customer.Address = address;

                        return View(customer);
                    }
                }
                // No match found! Change the page later...
                return Redirect("/404.html");
            }

        }


        // Allows deleting of customer
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
                int customerID = int.Parse(RouteData.Values["id"].ToString());

                // Establishes account model
                CustomerModel customerModel = new CustomerModel();                            

                // Deletes the account, and contact from the database using the ID
                customerModel.DeleteCustomer(customerID);
                
                // TODO: Confirm this is the correct return state
                // Return to the account page
                return Redirect("/Customer/deleteCustomers");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

    }
}