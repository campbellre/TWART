using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Handlers
{
    public class ContactHandler
    {
        // Constructor
        public ContactHandler()
        {}

        // Creates a contact
        public int create(String forename, String surname, String position, String phoneNumber)
        {
            // Establishes contact model
            ContactModel contactModel = new ContactModel();

            // Holds new contact
            Contact newContact = new Contact();

            // Stored details for the contact
            newContact.Forename = forename;
            newContact.Surname = surname;
            newContact.Position = position;
            newContact.PhoneNumber = phoneNumber;

            // Acquires contactID
            int contactID = contactModel.CreateContact(newContact);

            // Returns contactID
            return contactID;
        }

        //// Edits a contact
        //public ActionResult EditContact()
        //{
        //    // Null handling
        //    if (Session["loggedInState"] == null)
        //    {
        //        return Redirect("/403.html");
        //    }

        //    // Checks if logged in
        //    bool state = (bool)Session["loggedInState"];
        //    if (state == true)
        //    {
        //        // Creates contact placeholder
        //        var contact = new Contact();

        //        // Setup contact edit
        //        contact.ID = int.Parse(Request.Form["id"]);
        //        contact.Forename = Request.Form["forename"];
        //        contact.Surname = Request.Form["surname"];
        //        contact.Position = Request.Form["position"];
        //        contact.PhoneNumber = Request.Form["phoneNumber"];

        //        // Establish contact model
        //        var contactModel = new ContactModel();

        //        // Conduct edit
        //        contactModel.EditContact(contact);

        //        // Passes back to the view
        //        return View();
        //    }
        //    else
        //    {
        //        // If not logged in
        //        return Redirect("/login.html");
        //    }
        //}
    }
}