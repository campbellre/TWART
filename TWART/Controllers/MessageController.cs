using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.Models;
using TWART.DataObjects;


namespace TWART.Controllers
{
    public class MessageController : System.Web.Mvc.Controller
    {
        // Creates new message
        public ActionResult Create()
        {
            // Creates models
            MessageModel messageModel = new MessageModel();
            
            // Holds message placeholder
            Message newMessage = new Message();

            // Stored details for the customer
            newMessage.Name = Request.Form["name"];
            newMessage.Email = Request.Form["email"];
            newMessage.MessageBody = Request.Form["Message"];

            // Creates the message
            messageModel.CreateMessage(newMessage);

            // Return created message to view
            return Redirect("/TWART/Index");
        }

        // Deletes a message
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
                // Acquires the ID of the message
                int messageID = int.Parse(RouteData.Values["id"].ToString());

                // Establishes message model
                MessageModel messageModel = new MessageModel();

                // Deletes the message
                messageModel.DeleteMessage(messageID);

                // Return to the message page
                return Redirect("/..message");
            }
            else
            {
                // If not logged in
                return Redirect("/login.html");
            }
        }

        // Gets a list of messages
        public ActionResult ShowMessages()
        {
            // Null handling
            if (Session["loggedInState"] == null)
            {
                return Redirect("/403.html");
            }

            // If logged in
            bool state = (bool)Session["loggedInState"];
            if (state == true)
            {
                // Establishes message model
                MessageModel messageModel = new MessageModel();

                // Gets a complete list of messages
                var messageList = messageModel.ListMessages();

                // Returns the message list
                return View(messageList);
            }
            else
            {
                return Redirect("/403.html");
            }
        }
    }
}