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
        public ActionResult GetCustomers()
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
        public ActionResult EditCustomer()
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
                int customerID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

                // Creates object placeholders
                Customer customer = new Customer();

                // Setup customer edit
                customer.ID = int.Parse(Request.Form["customerID"]);
                customer.Name = Request.Form["name"];
                customer.Address_ID = int.Parse(Request.Form["addressID"]);
                customer.Account_ID = int.Parse(Request.Form["accountID"]);

                // Establishes customer model
                CustomerModel customerModel = new CustomerModel();

                // Conduct edit
                customerModel.EditCustomer(customer);

                // Passes back to the view
                return View();
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
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
                return Redirect("/..account");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

    }
}