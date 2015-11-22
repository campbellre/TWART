using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Handlers
{
    // allows creation of specification
    public class SpecificationHandler
    {
        // Constructor
        public SpecificationHandler()
        { }

        // Create specification
        public int create(int weight, int height, int width, int length)
        {
            // Establish models
            SpecificationModel specModel = new SpecificationModel();

            // Holds the new specification
            Specification newSpec = new Specification();

            // Stored details for the specification
            newSpec.Weight = weight;
            newSpec.Height = height;
            newSpec.Width = width;
            newSpec.Length = length;

            // Adds the object to the database
            int specificationID = specModel.NewSpecification(newSpec);

            // Return the specificationID
            return specificationID;
        }
    }
}