using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Handlers;
using TWART.Models;

namespace TWART.Controllers
{
    public class OrderController : System.Web.Mvc.Controller
    {

        public ActionResult create() {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }
            else {

                AddressModel addressModel = new AddressModel();
                List<Address> listAddresses = addressModel.GetAddressesList();

                return View(listAddresses);
            }
        }

        // GET: Order
        public ActionResult createOrder()
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
                // Creates handlers for order creating
                GoodsHandler goodsHand = new GoodsHandler();
                SpecificationHandler specHand = new SpecificationHandler();
                PackageHandler packHand = new PackageHandler();
                TransactionHandler tranHandler = new TransactionHandler();

                // Necessary models
                ClientUserModel cuModel = new ClientUserModel();
                OrderModel orderModel = new OrderModel();

                // Stored details for package specification
                int weight = int.Parse(Request.Form["weight"]);
                int height = int.Parse(Request.Form["height"]);
                int length = int.Parse(Request.Form["length"]);
                int width = int.Parse(Request.Form["width"]);

                // Stored details for package
                String name = Request.Form["goodsDescriptor"];
                String handling = Request.Form["options"];


                String deliveryType = Request.Form["deliveryBands"];

                // Stored details for order
                int deliveryBand = 0;

                switch (deliveryType) 
                { 
                    case "Next Day Delivery":
                        deliveryBand = 1;
                        break;
                    case "Express 1-2 Days":
                        deliveryBand = 2;
                        break;
                    case "Standard 3-5 Days":
                        deliveryBand = 3;
                        break;
                    case "Basic 5-10 Days":
                        deliveryBand = 4;
                        break;
                }


                // Holds the order objects
                Order newOrder = new Order();

                // Creates the foreign objects, and gets the IDs
                int goodsID = goodsHand.create(name, handling);
                int specID = specHand.create(weight, height, length, width);
                int packID = packHand.create(goodsID, specID);

                // Acquires client data
                ClientUser thisUser = cuModel.SearchClientUser(int.Parse(Session["userID"].ToString()));

                // Acquires account type (Standard | Premium)
                AccountModel accModel = new AccountModel();
                Account thisAccount = accModel.SearchAccount(thisUser.AccountID);
                int accountType = thisAccount.AccountTypeID;

                // Sets up the order
                newOrder.AccountID = thisUser.AccountID;
                newOrder.DestinationAddressID = int.Parse(Request.Form["address2"]);
                newOrder.SourceAddressID = int.Parse(Request.Form["address1"]);
                newOrder.Placed = DateTime.Now;
                newOrder.OrderStatus = "Placed";
                newOrder.GoodsID = goodsID;

                // Calculate desired delivery date
                newOrder.DesiredDeliveryDate = calcDesiredDeliveryDate(deliveryBand, newOrder.Placed);

                // Price of order
                PackageModel packageModel = new PackageModel();
                Package thisPackage = packageModel.SearchPackage(packID);
                int totalPrice = calcPrice(accountType, deliveryBand, thisPackage);

                // Creates the order
                int orderID = orderModel.CreateOrder(newOrder);

                // Sets up a transaction
                tranHandler.create(orderID, thisAccount.CustomerID, thisAccount.BankID);

                // Passes back to the view
                return View(newOrder);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        #region Internal calculations
        // Calculates the total cost of the order
        private int calcPrice(int accountType, int deliveryBand, Package thisPackage)
        {
            int runningTotal = calcBaseCost(thisPackage);
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
        private int calcBaseCost(Package thisPackage)
        {
            // In pence
            int runningCost = 0;

            // Iterates through the packages in the list
            Specification thisSpec = thisPackage.Specification;

            // Works out delivery band
            if (thisSpec.Length <= 42 && thisSpec.Width <= 34 && thisSpec.Height <= 27 && thisSpec.Weight <= 100)
            {
                runningCost += 1500;
            }
            else if (thisSpec.Length <= 50 && thisSpec.Width <= 45 && thisSpec.Height <= 34 && thisSpec.Weight <= 250)
            {
                runningCost += 2100;
            }
            else if (thisSpec.Length <= 60 && thisSpec.Width <= 54 && thisSpec.Height <= 41 && thisSpec.Weight <= 400)
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

            // Returns the collective running cost
            return runningCost;
        }

        // Calculates the desired delvery date (maximum range)
        private DateTime calcDesiredDeliveryDate(int deliveryBand, DateTime baseDate)
        {
            // Adds to the base date based on delivery band
            switch (deliveryBand)
            {
                case 1: baseDate.AddHours(24);
                    break;
                case 2: baseDate.AddDays(2);
                    break;
                case 3: baseDate.AddDays(5);
                    break;
                case 4: baseDate.AddDays(10);
                    break;
            }

            // Returns the base date
            return baseDate;
        }
        #endregion
    }
}