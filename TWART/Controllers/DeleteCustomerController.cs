using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.Models;

namespace TWART.Controllers
{
    public class DeleteCustomerController : System.Web.Mvc.Controller
    {
        // GET: DeleteCustomer
        public ActionResult Index()
        {

            int id = int.Parse(RouteData.Values["id"].ToString());

            // Create a customer model object
            CustomerModel customerModel = new CustomerModel();

            // Call the method to delete a customer from the database
            customerModel.DeleteCustomer(id);

            return Redirect("index.html");
        }
    }
}