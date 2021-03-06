﻿using System;
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
                foreach (var customer in customerList)
                {
                    Address address = addressModel.SearchAddress(customer.Address_ID);
                    customer.Address = address;
                }
                // Return the CustomerList
                return View(customerList);
            }
        }
        public ActionResult Edit()
        {
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            bool state = (bool)Session["loggedInState"];
            if (state == true)
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
                return Redirect("/login.html");
            }
        }
        public ActionResult Index()
        {
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                return Redirect("/Index/adminIndex");
            }
            else
            {
                return Redirect("/login.html");
            }
        }
        public ActionResult newCustomer()
        {
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                var addresses = new AddressModel();
                var addresslist = addresses.GetAddressesList();
                return View(addresslist);
            }
        }
        public ActionResult adminIndex()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Users()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Address()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Bank()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Accounts()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Employees()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Orders()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }
        }
        public ActionResult CreateUser()
        {
            String username = Request.Form["username"].ToString();
            String password = Request.Form["password"].ToString();
            User user = new User();
            user.username = username;
            user.password = password;
            user.AccessLevel = "Admin";
            LoginModel loginMod = new LoginModel();
            loginMod.CreateUser(user);
            return Redirect("adminIndex");
        }


        public ActionResult Delete()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                CustomerModel cm = new CustomerModel();
                Customer c = cm.SearchCustomers(int.Parse(RouteData.Values["id"].ToString()));
                return View(c);
            }
        }
        public ActionResult deleteThis()
        {
            CustomerModel deleteMe = new CustomerModel();
            deleteMe.DeleteCustomer(int.Parse(Request.Form["ID"]));
            return Redirect("Customer");
        }
        public ActionResult afterdelete()
        {
            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }
        }
        public ActionResult afterupdate()
        {

            //If there is no valid session, return forbidden
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                return View();
            }

        }
        public ActionResult createCustomer()
        {
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else
            {
                int id = int.Parse(Request.Form["newAddress"]);
                String name = Request.Form["newClientName"];
                Customer client = new Customer();
                client.Name = name;
                client.Address_ID = id;
                var cm = new CustomerModel();
                cm.CreateCustomer(client);
                return Redirect("Customer");
            }
        }
        public ActionResult ViewInfo()
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
        public ActionResult Logout()
        {
            doLogout();
            // redirect the user to the index page
            return Redirect("../index.html");
        }
        private bool doLogout()
        {
            // Sets the Session variable
            Session["loggedInState"] = null;
            Session["loggedInUser"] = null;
            // Returns bool. State of the Logout attempt
            return true;
        }

    }
}