using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    // Handles the searching within the program
    public class Search
    {
        // Class parameters
        int searchType;
        string[][] parameters; // [Table].Column-name | Search parameter
        
        // Constructor
        public Search(int searchType, string[][] inputParameters)
        {
            this.searchType = searchType;
            this.parameters = inputParameters;
        }

        // Controls the flow of the searches
        public void searchController()
        {
            // Branches search
                switch(searchType)
                {
                    case 1: doSearchClient();
                        break;
                    case 2: doSearchDelivery();
                        break;


                    default: // Error
                        break;
                }
        }

        #region Searches
        // Searches for a client
        private void doSearchClient()
        {
            // Assign local names
            string clientName = parameters[0][1];
            string companyName = parameters[1][1];
            string address = parameters[2][1];

            // Checks validity of parameters
            if (doValidation(clientName) && doValidation(companyName) && doValidation(address))
            {
                // Validation successful
            }
            else
            {
                // Change a text box to display error message (Toysif - UI)
            }
        }

        // Searches for a delivery
        private void doSearchDelivery()
        {

        }

        // Searches for an address
        private void doSearchAddress()
        {

        }

        // Searches for contact
        private void doSearchContact()
        {
            string forename = parameters[0][1];
            string surname = parameters[1][1];
            string position = parameters[2][1];
            string telephone = parameters[3][1];
        }

        // Searches for depot
        private void doSearchDepot()
        {
            string name = parameters[0][1];
            string size = parameters[1][1];
            string noOfVehicles = parameters[2][1];
            string manager = parameters[3][1];
        }

        // Searces for department
        private void doSearchDepartment()
        {
            string title = parameters[0][1];
            string head = parameters[1][1];
        }

        // Searches for company
        private void doSearchCompany()
        {
            string companyName = parameters[0][1];
        }
        #endregion

        #region Error Handling
        // Conducts error handling on array value
        private bool doValidation(string checkValue)
        {
            if (checkValue != null)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}