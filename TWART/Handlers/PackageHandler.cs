using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Handlers
{
    // Allows creation of a package
    public class PackageHandler
    {
        // Constructor
        public PackageHandler()
        { }

        // Creates a new package
        public int create(int goodsID, int specificationID)
        {
            // Establishes package models
            PackageModel packageModel = new PackageModel();

            // Holds the new package
            Package newPackage = new Package();
           
            // Stored details for the package
            newPackage.GoodsID = goodsID;
            newPackage.SpecificationID = specificationID;

            // Adds the object to the database
            int packageID = packageModel.CreatePackage(newPackage);

            // Returns the package ID
            return packageID;
        }
    }
}