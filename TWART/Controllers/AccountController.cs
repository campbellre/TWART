using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class AccountController : System.Web.Mvc.Controller
    {
        // GET: Account
        public ActionResult Index()
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
                AccountModel accountModel = new AccountModel();
                AccountTypeModel accountTypeModel = new AccountTypeModel();
                ContactModel contactModel = new ContactModel();

                // Holds the new account
                Account newAccount = new Account();
                Account_Type accountType = new Account_Type();
                Contact newContact = new Contact();

                // Get the account type int
                int accountTypeID = int.Parse(Request.Form["accountTypeID"]);

                // Stored details for the account type
                accountType = accountTypeModel.SearchAccountType(accountTypeID);

                // Stored details for the contact
                newContact.Forename = Request.Form[2];
                newContact.Surname = Request.Form[3];
                newContact.Position = Request.Form[4];
                newContact.PhoneNumber = Request.Form[5];

                // Commences save to database
                int contactID = contactModel.CreateContact(newContact);

                // Stored details for the account
                newAccount.CustomerID = int.Parse(Request.Form[0]);
                newAccount.ContactID = contactID;
                newAccount.AccountTypeID = accountTypeID;
                newAccount.BankID = int.Parse(Request.Form[1]);
                
                // Creates the account
                accountModel.CreateAccount(newAccount);

                // Return created department to view
                return View(newAccount);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        [HttpPost]
        // Controller for modification of a department
        public ActionResult EditAccount()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Creates object placeholders
                var account = new Account();
                var contact = new Contact();

                // Setup contact edit
                contact.ID = int.Parse(Request.Form["id"]);
                contact.Forename = Request.Form["forename"];
                contact.Surname = Request.Form["surname"];
                contact.Position = Request.Form["position"];
                contact.PhoneNumber = Request.Form["phoneNumber"];

                // Setup account edit
                account.ID = int.Parse(Request.Form["id"]);
                account.ContactID = int.Parse(Request.Form["contactID"]);
                account.CustomerID = int.Parse(Request.Form["customerID"]);
                account.AccountTypeID = int.Parse(Request.Form["accountTypeID"]);
                account.BankID = int.Parse(Request.Form["bankID"]);

                // Establish models
                var accountModel = new AccountModel();
                var contactModel = new ContactModel();

                // Conduct edit
                contactModel.EditContact(contact);
                accountModel.EditAccount(account);

                // Passes back to the view
                return View();
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Deletes an account from the database
        public ActionResult Delete()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // Checks if logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                int accountID = int.Parse(RouteData.Values["id"].ToString());

                // Establishes account model
                ContactModel contactModel = new ContactModel();
                AccountModel accountModel = new AccountModel();

                // Acquires the contactID
                Account toDelete = accountModel.SearchAccount(accountID);
                int contactID = toDelete.ContactID;

                // Deletes the account, and contact from the database using the ID
                contactModel.DeleteContact(contactID);
                accountModel.DeleteAccount(accountID);

                // TODO: Confirm this is the correct return state
                // Return to the account page
                return Redirect("/..account");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Gets a full list of accounts
        public ActionResult AccountList()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                Redirect("403.html");
            }

            // If logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Establishes list of models
                var accountModel = new AccountModel();
                var contactModel = new ContactModel();
                var accountTypeModel = new AccountTypeModel();
                var customerModel = new CustomerModel();
                var bankModel = new BankingModel();

                // Gets list of accounts
                var al = accountModel.ListAccounts();

                // Attaches associated contact / accountType / customer / bank to account
                foreach (var account in al)
                {
                    // Acquires contact from contactID
                    Contact contact = null;
                    if (account.ContactID != 0)
                    {
                        contact = contactModel.SearchContact(account.ContactID);
                    }

                    // Acquires accountType from accountTypeID
                    Account_Type accountType = null;
                    if (account.AccountTypeID != 0)
                    {
                        accountType = accountTypeModel.SearchAccountTypeModel(accountTypeID);
                    }

                    // Acquires customer from customerID
                    Customer customer = null;
                    if (account.CustomerID != 0)
                    {
                        customer = customerModel.SearchCustomers(account.CustomerID);
                    }

                    // Acquires bank from bankID
                    Bank bank = null;
                    if (account.BankID != 0)
                    {
                        bank = bankModel.SearchBank(account.BankID);
                    }

                    // Appends objects to account
                    account.Contact = contact;
                    account.AccountType = accountType;
                    account.Customer = customer;
                    account.Bank = bank;
                }

                // Return list of departments
                return View(al);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
    }
}