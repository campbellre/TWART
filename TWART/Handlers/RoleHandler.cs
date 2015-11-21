using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Handlers
{
    public class RoleHandler
    {
        // Constructor
        public RoleHandler()
        {}

        // Creates a contact
        public int create(String title)
        {
            // Establishes depot model
            DepotModel depoModel = new DepotModel();

            // Holds new depot
            Depot newDepot = new Depot();

            // Stored details for the depot
            //newDepot.AddressID = addressID;
            //newDepot.DepotName = depotName;
            //newDepot.FloorSpace = floorSpace;

            // Acquires depotID
            int depotID = depoModel.CreateDepot(newDepot);

            // Returns depotID
            return depotID;
        }
    }
}