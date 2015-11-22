using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class TransactionController : System.Web.Mvc.Controller
    {
        // Gets all transactions
        public ActionResult GetTransactions()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Creates the models
                var transModel = new TransactionModel();
                var orderModel = new OrderModel();
                var custModel = new CustomerModel();
                var bankModel = new BankingModel();

                // Gets the complete list
                var tl = transModel.ListTransactions();

                if (tl.Count != 0)
                {
                    // Attaches associated order / customer / bank to transaction
                    foreach (var trans in tl)
                    {
                        // Acquires, and adds the order to transaction
                        Order order = null;
                        if (trans.OrderID != 0)
                        {
                            order = orderModel.SearchOrder(trans.OrderID);
                        }

                        // Acquires, and adds the customer to transaction
                        Customer cust = null;
                        if (trans.CustomerID != 0)
                        {
                            cust = custModel.SearchCustomers(trans.CustomerID);
                        }

                        // Acquires, and adds the bank to transaction
                        Bank bank = null;
                        if (trans.BankID != 0)
                        {
                            bank = bankModel.SearchBank(trans.BankID);
                        }
                    }
                }

                // Returns the list
                return View(tl);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
    }
}