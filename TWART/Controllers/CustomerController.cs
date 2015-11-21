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
        // Gets list of customers
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
                // Establishes models
                CustomerModel customerModel = new CustomerModel();
                AddressModel addressModel = new AddressModel();

                // Call the method to get the list
                var customerList = customerModel.ListCustomers();

                // For each customer in the list
                foreach (var customer in customerList)
                {
                    // Find associated address
                    Address address = addressModel.SearchAddress(customer.Address_ID);

                    // Append address to customer object
                    customer.Address = address;
                }

                // Returns the customer list
                return View(customerList);
            }

            else
            {
                // If not logged in
                return Redirect("/login.html");
            }

        }

        // View individual customer details
        public ActionResult view()
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
                // Establishes models
                CustomerModel customerModel = new CustomerModel();
                AddressModel addressModel = new AddressModel();

                // Call the method to get the list
                var customerList = customerModel.ListCustomers();

                // Get the ID requested
                int customerID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

                // For each customer in the list
                foreach (var customer in customerList)
                {
                    // If their ID matches
                    if (customer.ID == customerID)
                    {
                        // Find associated address
                        Address address = addressModel.SearchAddress(customer.Address_ID);

                        // Append address to customer object
                        customer.Address = address;

                        // Return customer object
                        return View(customer);
                    }
                }
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }

            // Something went wrong
            return Redirect("/404.html");
        }


        // View individual customer details
        public ActionResult editPage()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }


            // Get the ID requested
            int id = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

            CustomerModel customerModel = new CustomerModel();
            Customer customer = customerModel.SearchCustomers(id);

            // If logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Return customer object
                return View(customer);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Allows editing of a customer
        public ActionResult edit()
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
                // Creates an department placeholder
                Customer customer = new Customer();

                // Establish customer model
                CustomerModel customerModel = new CustomerModel();

                // Setup address edit
                customer.ID = int.Parse(Request.Form["id"]);
                customer.Address_ID = int.Parse(Request.Form["addressID"]);
                customer.Name = Request.Form["customerName"];

                // Conduct edit
                customerModel.EditCustomer(customer);

                // Passes back to the view
                return Redirect("/Customer/Customer");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }


        // Allows deleting of customer
        public ActionResult delete()
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

                // Return to the account page
                return Redirect("/Customer/Customer");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
    }
}