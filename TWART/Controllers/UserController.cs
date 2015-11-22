using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.Handlers;
using TWART.Models;
using TWART.DataObjects;

namespace TWART.Controllers
{
    public class UserController : System.Web.Mvc.Controller
    {
        // Creates a new client user
        public ActionResult CreateClient()
        {
            // Ensures logged in
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Establishes models
                ClientUserModel cModel = new ClientUserModel();

                // Establishes handlers
                AccountHandler accHand = new AccountHandler();
                AddressHandler addHand = new AddressHandler();
                BankHandler banHand = new BankHandler();
                ContactHandler conHand = new ContactHandler();
                CustomerHandler cusHand = new CustomerHandler();

                // Extract for account details
                int accountType = int.Parse(Request.Form["accountType"]);

                // Extract for bank details
                String sortCode = Request.Form["sortCode"];
                int accountNumber = int.Parse(Request.Form["accountNum"]);

                // Extract for client details
                String username = Request.Form["username"];
                String password = Request.Form["password"];
                String name = Request.Form["clientName"];

                // Extract contact details
                String forename = Request.Form["forename"];
                String surname = Request.Form["surname"];
                String position = Request.Form["position"];
                String phoneNumber = Request.Form["phoneNum"];

                // Extract bank address details
                String blineOne = Request.Form["bankL1"];
                String blineTwo = Request.Form["bankL2"]; ;
                String blineThree = Request.Form["bankL3"];
                String blineFour = Request.Form["bankL4"];
                String blineFive = Request.Form["bankL5"];
                String bcState = Request.Form["bankState"];
                String bcounty = Request.Form["bankCounty"];
                String bcountry = Request.Form["bankCountry"];
                String bpostalCode = Request.Form["bankPostalCode"];

                // Extract for customer details
                String compName = Request.Form["compName"];

                // Extract customer address details
                String clineOne = Request.Form["custL1"];
                String clineTwo = Request.Form["custL2"]; ;
                String clineThree = Request.Form["custL3"];
                String clineFour = Request.Form["custL4"];
                String clineFive = Request.Form["custL5"];
                String ccState = Request.Form["custState"];
                String ccounty = Request.Form["custCounty"];
                String ccountry = Request.Form["custCountry"];
                String cpostalCode = Request.Form["custPostalCode"];

                // Creates objects for user
                int bankAddressID = addHand.create(blineOne, blineTwo, blineThree, blineFour, blineFive, bcState,
                                                   bcounty, bcountry, bpostalCode);
                int custAddressID = addHand.create(clineOne, clineTwo, clineThree, clineFour, clineFive, ccState,
                                                   ccounty, ccountry, cpostalCode);
                int bankID = banHand.create(bankAddressID, sortCode, accountNumber);
                int contactID = conHand.create(forename, surname, position, phoneNumber);
                int customerID = cusHand.create(compName, custAddressID);
                int accountID = accHand.create(accountType, bankID, customerID, contactID);

                // Holds new objects
                ClientUser newClient = new ClientUser();

                // Acquires needed Account ID
                newClient.Username = username;


                // Stored details for the customer
                newClient.Name = name;
                newClient.Username = username;
                newClient.Password = password;
                newClient.AccountID = accountID;
                
                // Creates the customer
                int clientID = cModel.CreateClientUser(newClient);

                // Return created department to view
                return View(newClient);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Creates a new employee user
        public ActionResult CreateEmployee()
        {
            // Ensures logged in
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Establishes models
                LoginModel eModel = new LoginModel();

                // Stored details for the employee
                String firstname = Request.Form["firstname"];
                String surname = Request.Form["lastname"];
                DateTime DOB = DateTime.Parse(Request.Form["DOB"]);
                String contactNum = Request.Form["contactNum"];
                DateTime startDate = DateTime.Parse(Request.Form["startDate"]);
                int dept = int.Parse(Request.Form["dept"]);
                int depot = int.Parse(Request.Form["depot"]);
                int role = int.Parse(Request.Form["role"]);

                // Stored details for the user
                String username = Request.Form["username"];
                String password = Request.Form["password"];
                String email = Request.Form["email"];
                String accessLevel = Request.Form["accessLevel"];

                // Establishes handlers
                EmployeeHandler emHandler = new EmployeeHandler();

                // Creates employee for user
                int employeeID = emHandler.create(firstname, surname, DOB, contactNum, startDate, dept, depot, role);

                // Holds new object
                User newUser = new User();

                // Creates user details
                newUser.username = username;
                newUser.password = password;
                newUser.email = email;
                newUser.AccessLevel = accessLevel;

                // Return created department to view
                return View(newUser);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
    }
}