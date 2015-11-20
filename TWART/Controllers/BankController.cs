using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.Models;
using TWART.DataObjects;

namespace TWART.Controllers
{
    public class BankController : System.Web.Mvc.Controller
    {
        // GET: Bank
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

                // Establishes bank model
                BankingModel bankModel = new BankingModel();

                // Holds the new bank details
                Bank newBank = new Bank();

                // Stored details for the bank
                newBank.Address_ID = int.Parse(Request.Form[0]);
                newBank.SortCode = Request.Form[1];
                newBank.AccountNumber = int.Parse(Request.Form[1]);
                newBank.Customer_ID = int.Parse(Request.Form[2]);

                // Adds the object to the database
                bankModel.CreateBank(newBank);

                // Return the created bank to view
                return View(newBank);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Returns a list of all banks
        public ActionResult GetBanks()
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
                var bankModel = new BankingModel();
                var addressModel = new AddressModel();
                var customerModel = new CustomerModel();
                
                // Gets the complete list
                var bl = bankModel.ListBanking();

                if (bl.Count != 0)
                {
                    // Attaches associated department / role to employee
                    foreach (var bank in bl)
                    {
                        // Acquires, and adds the bank address
                        Address address = null;
                        if (bank.Address_ID != 0)
                        {
                            address = addressModel.SearchAddress(bank.Address_ID);
                        }
                        
                        // Acquires, and adds the customer details
                        Customer customer = null;
                        if (bank.Customer_ID != 0)
                        {
                            customer = customerModel.SearchCustomers(bank.Customer_ID);
                        }

                        // Appends objects to bank
                        bank.Address = address;
                        bank.Customer = customer;
                    }

                    // Returns the list
                    return View(bl);
                }
                else
                {
                    return Redirect("/403.html");
                }
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
    }
}