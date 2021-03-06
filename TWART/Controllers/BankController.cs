﻿using System;
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
        // Returns a list of all banks
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
                // Creates models
                var bankModel = new BankingModel();
                var addressModel = new AddressModel();
                
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

                        // Appends object to bank
                        bank.Address = address;
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