using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.Models;
using TWART.DataObjects;

namespace TWART.Handlers
{
    public class BankHandler
    {
        // Constructor
        public BankHandler()
        {}

        // Creates a bank
        public int create(int addressID, String sortCode, int accountNumber)
        {
            // Establishes model
            BankingModel bankModel = new BankingModel();

            // Holds the new bank
            Bank newBank = new Bank();

            // Stored details for the bank
            newBank.Address_ID = addressID;
            newBank.SortCode = sortCode;
            newBank.AccountNumber = accountNumber;

            // Creates the bank
            int bankID = bankModel.CreateBank(newBank);

            // Returns created bank
            return bankID;
        }

        //// Returns a list of all banks
        //public ActionResult GetBanks()
        //{
        //    // Null handling
        //    if (Session["loggedInState"] == null)
        //    {
        //        return Redirect("/403.html");
        //    }

        //    // If logged in
        //    bool state = (bool)Session["loggedInState"];
        //    if (state == true)
        //    {
        //        // Creates models
        //        var bankModel = new BankingModel();
        //        var addressModel = new AddressModel();
                
        //        // Gets the complete list
        //        var bl = bankModel.ListBanking();

        //        if (bl.Count != 0)
        //        {
        //            // Attaches associated department / role to employee
        //            foreach (var bank in bl)
        //            {
        //                // Acquires, and adds the bank address
        //                Address address = null;
        //                if (bank.Address_ID != 0)
        //                {
        //                    address = addressModel.SearchAddress(bank.Address_ID);
        //                }

        //                // Appends object to bank
        //                bank.Address = address;
        //            }

        //            // Returns the list
        //            return View(bl);
        //        }
        //        else
        //        {
        //            return Redirect("/403.html");
        //        }
        //    }
        //    else
        //    {
        //        // If not logged in
        //        return Redirect("/login.html");
        //    }
        //}
    }
}