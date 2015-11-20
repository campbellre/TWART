using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class ContactController : System.Web.Mvc.Controller
    {
        // GET: Contact
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
                // Establishes contact model
                ContactModel contactModel = new ContactModel();

                // Holds the new contact
                Contact newContact = new Contact();

                // Stored details for the contact
                newContact.Forename = Request.Form[0];
                newContact.Surname = Request.Form[1];
                newContact.Position = Request.Form[2];
                newContact.PhoneNumber = Request.Form[3];              

                // Adds the object to the database
                contactModel.CreateContact(newContact);

                // Return created contact to view
                return View(newContact);
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Controller for modification of a contact
        public ActionResult EditContact()
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
                // Creates a contact placeholder
                var contact = new Contact();

                // Setup contact edit
                contact.ID = int.Parse(Request.Form["id"]);
                contact.Forename = Request.Form["forename"];
                contact.Surname = Request.Form["surname"];
                contact.Position = Request.Form["position"];
                contact.PhoneNumber = Request.Form["phoneNumber"];

                // Establishes contact model
                var contactModel = new ContactModel();

                // Conduct edit
                contactModel.EditContact(contact);

                // Passes back to the view
                return View();
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Deletes a contact
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
                int contactID = int.Parse(RouteData.Values[""].ToString());

                // Establishes contact model
                ContactModel contactModel = new ContactModel();

                // Deletes the contact from the database using the ID
                contactModel.DeleteContact(contactID);

                return Redirect("/..contact");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }
    }
}