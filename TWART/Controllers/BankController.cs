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
            //get the ID from the front-end
            var ID = int.Parse(Request.Form["id"]);

            //get a customer object based on the id
            var customerModel = new CustomerModel();
            var customer = customerModel.SearchCustomers(ID);

            //get a bank object - search for a bank which matches customer
            var bankModel = new BankingModel();
            var bank = bankModel.SearchBanking(customer);

            //return the bank object
            return View(bank);
        }
    }
}