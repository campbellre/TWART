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
                return Redirect("/Admin/adminIndex");
            }
            else
            {
                return Redirect("/login.html");
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
        public ActionResult Banking()
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
        public ActionResult EditCustomer()
        {
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                var c = new Customer();
                c.ID = int.Parse(Request.Form["id"]);
                c.Name = Request.Form["name"].ToString();
                c.Address_ID = int.Parse(Request.Form["addressid"]);
                var cm = new CustomerModel();
                cm.EditCustomer(c);
                return Redirect("afterupdate");
            }
            else
            {
                return Redirect("/login.html");
            }
        }
        public ActionResult CreateCustomer()
        {
            String username = RouteData.Values["username"].ToString();
            String password = RouteData.Values["password"].ToString();
            User user = new User();
            user.username = username;
            user.password = password;
            LoginModel loginMod = new LoginModel();
            loginMod.CreateUser(user);
            return Redirect("Customer");
        }
        public ActionResult Delete()
        {
            return View();
            //int id = int.Parse(RouteData.Values["id"].ToString());
            // Create a customer model object
            ///CustomerModel customerModel = new CustomerModel();
            // Call the method to delete a customer from the database
           // customerModel.DeleteCustomer(id);
           // return Redirect("Customer");
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
                foreach (var customer in customerList)
                {
                    Address address = addressModel.SearchAddress(customer.Address_ID);
                    customer.Address = address;
                }
                // Return the CustomerList
                return View(customerList);
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