using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controller
{
    // Handles the setting up of an order
    public class CreateOrder
    {
        // Class parameters
        int accountID;
        int clientID;
        int deliveryBand;
        List<Package> packageList = new List<Package>();
        DateTime placed;
        int totalPrice;

        // Class constructor
        public CreateOrder(int accountID, List<Package> incomingList)
        {
            this.accountID = accountID;
            packageList = incomingList;
            placed = DateTime.Now;

            // Gets the account type (Admin, etc.)
            int accountType = getAccountType();

            // Calculates the price of the order
            totalPrice = calcPrice(accountType);
        }

        #region Internal calculations
        // Calculates the account type
        private int getAccountType()
        {
            // Establishes the account model
            AccountModel accountControl = new AccountModel();

            // Searches for the account
            Account thisAccount = accountControl.GetAccount(accountID);

            // Returns the account type
            return thisAccount.ID;
        }

        // Calculates the total cost of the order
        private int calcPrice(int accountType)
        {
            int runningTotal = calcBaseCost();
            float modifier = 0f;
            
            // Determines account benefit modifier
            switch(accountType)
            {
                case 1: modifier = 1;
                    break;
                case 2: modifier = 0.9f;
                    break;
                default: modifier = 1;
                    break;
            }

            // Determines delivery modifier
            switch(deliveryBand)
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
        private int calcBaseCost()
        {
            // In pence
            int runningCost = 0;

            // Iterates through the packages in the list
            foreach(Package p in packageList)
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

            return runningCost;
        }
        #endregion
    }
}