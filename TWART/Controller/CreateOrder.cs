using System;
using System.Collections;
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
        ArrayList<Package> packageList = new ArrayList<Package>();
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