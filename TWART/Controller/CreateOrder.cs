using System;
using System.Collections;
using System.Collections.Generic;
using TWART.DataObjects;
using System.Linq;
using System.Web;

namespace TWART.Controller
{
    // Handles the setting up of an order
    public class CreateOrder
    {
        // Class parameters
        int orderID;
        int accountID;
        int clientID;
        List<Package> packageList = new List<Package>();
        DateTime placed;

        // Class constructor
        public CreateOrder()
        {
            // CONSTRUCTOR GOES HERE
        }

        // Calculates the total cost of the order
        private void calcPrice()
        {

        }
    }
}