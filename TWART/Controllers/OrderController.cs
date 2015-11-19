using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class OrderController : System.Web.Mvc.Controller
    {
        // GET: Order
        [HttpPost]
        public ActionResult orderpost()
        {
            // Ensures logged in
            try
            {
                // Checks if logged in
                bool state = (bool)Session["loggedInState"];
                if (state == true)
                {
                    // Creates a new order model
                    OrderModel orderModel = new OrderModel();

                    // Holds the order
                    Order newOrder = new Order();
                    newOrder.Placed = DateTime.Now;

                    // Stored details
                    int userID = (int)Session["userID"];
                    int deliveryBand = int.Parse(Request.Form[0]);

                    List<Package> packageList = new List<Package>();

                    // Acquires type of account (Standard | Premium)
                    int accountType = getAccountType(userID);

                    // Price of order
                    int totalPrice = calcPrice(accountType, deliveryBand, packageList);

                    return View();
                }
                else
                {
                    return Redirect("/login.html");
                }
           }
           catch (Exception e)
           {
                return Redirect("/403.html");
           }                
        }

        #region Internal calculations
        // Calculates the account type
        private int getAccountType(int userID)
        {
            // Establishes the account model
            AccountModel accountControl = new AccountModel();

            // Searches for the account
            Account thisAccount = accountControl.GetAccount(userID);

            // Returns the account type
            return thisAccount.ID;
        }

        // Calculates the total cost of the order
        private int calcPrice(int accountType, int deliveryBand, List<Package> packageList)
        {
            int runningTotal = calcBaseCost(packageList);
            float modifier = 0f;

            // Determines account benefit modifier
            switch (accountType)
            {
                case 1: modifier = 1;
                    break;
                case 2: modifier = 0.9f;
                    break;
                default: modifier = 1;
                    break;
            }

            // Determines delivery modifier
            switch (deliveryBand)
            {
                case 1: modifier *= 2;      // Next Day Delivery
                    break;
                case 2: modifier *= 1.6f;   // Express 1-2 Days Delivery
                    break;
                case 3: modifier *= 1.2f;   // (Next) Saturday Delivery
                    break;
                case 4: modifier *= 1;      // Standard 3-5 Days Delivery
                    break;
                default: modifier *= 1;     // Not reached
                    break;
            }

            // Apply modifiers
            float finalCost = (float)runningTotal * modifier;

            // Return the calculated total
            return (int)finalCost;
        }

        // Calculates the base cost of the package based on dimensions / weight
        private int calcBaseCost(List<Package> packageList)
        {
            // In pence
            int runningCost = 0;

            // Iterates through the packages in the list
            foreach (Package p in packageList)
            {
                Specification thisSpec = p.Specification;

                if (thisSpec.Length <= 42 && thisSpec.Width <= 34 && thisSpec.Height <= 27 && thisSpec.Weight <= 10)
                {
                    runningCost += 1500;
                }
                else if (thisSpec.Length <= 50 && thisSpec.Width <= 45 && thisSpec.Height <= 34 && thisSpec.Weight <= 25)
                {
                    runningCost += 2100;
                }
                else if (thisSpec.Length <= 60 && thisSpec.Width <= 54 && thisSpec.Height <= 41 && thisSpec.Weight <= 40)
                {
                    runningCost += 3000;
                }
                else if (thisSpec.Length <= 96 && thisSpec.Width <= 15 && thisSpec.Height <= 15)
                {
                    runningCost += 1750;
                }
                else // Catch
                {
                    // Outwith package band fee
                    runningCost += 3500;
                }
            }

            // Returns the collective running cost
            return runningCost;
        }
        #endregion



    }
}