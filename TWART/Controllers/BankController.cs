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
            var ID = int.Parse(Request.Form["id"]);

            // calculate Account_ID based on Customer ID
            var customerModel = new CustomerModel();
            var c = customerModel.SearchCustomers(ID);
            var accountID = c.Account_ID;

            // using the Account_ID, calculate Bank_ID
            var accountModel = new AccountModel();
            var a = accountModel.GetAccount(accountID);
            var theBank = a.BankID;

            // using the Bank_ID, get the bank details


            // PASS A CUSTOMER TO THE BANKMODEL

            return View(theBank);
        }
    }
}