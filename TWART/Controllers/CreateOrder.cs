using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using TWART.DataObjects;

namespace TWART.Controller
{
    // Handles the setting up of an order
    public class CreateOrder
    {
        // Class parameters
        int accountID;
        int clientID;
        List<Package> packageList = new List<Package>();
        DateTime placed;

        // Class constructor
        public CreateOrder(int accountID, List<Package> incomingList)
        {
            this.accountID = accountID;
            packageList = incomingList;
            placed = DateTime.Now;

            

            int totalPrice = calcPrice();

        }

        // Calculates the account type
        

        // Calculates the total cost of the order
        private int calcPrice()
        {
            return 0;
        }
    }
}