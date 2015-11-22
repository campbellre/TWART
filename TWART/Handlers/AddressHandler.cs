using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Handlers
{
    // Handles access to the Address classes for direct database modification (used to create new addresses)
    public class AddressHandler
    {
        // Constructor
        public AddressHandler()
        { }

        // Create address
        public int create(String lineOne, String lineTwo, String lineThree, String lineFour, String lineFive,
                              String state, String county, String country, String postCode)
        {
            // Creates an address model
            AddressModel addressModel = new AddressModel();

            // Holds the new address
            Address newAddress = new Address();

            // Stored details for address
            newAddress.LineOne = lineOne;
            newAddress.LineTwo = lineTwo;
            newAddress.LineThree = lineThree;
            newAddress.LineFour = lineFour;
            newAddress.LineFive = lineFive;
            newAddress.State = state;
            newAddress.County = county;
            newAddress.Country = country;
            newAddress.PostalCode = postCode;

            // Adds the object to the database. Returns address ID
            int addressID = addressModel.CreateAddress(newAddress);

            // Return address ID
            return addressID;
        }
    }
}