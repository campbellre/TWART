using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Controllers
{
    public class AdminController : System.Web.Mvc.Controller
    {

        public ActionResult Customer()
        {
            var cm = new CustomerModel();

            var cl = cm.ListCustomers();

            return View(cl);
        }

        public ActionResult Edit()
        {

            var p = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());

            var cm = new CustomerModel();

            var c = cm.SearchCustomers(p);


            return View(c);


        }

		
		public ActionResult GetAddress(){
		
            var id = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
			 
			var addressModel = new AddressModel();
			
			var address = addressModel.SearchAddress(id);
			
			return View(address);
			
		}


        [HttpPost]
        public ActionResult EditCustomer()
        {
            var c = new Customer();
            c.ID = int.Parse(Request.Form["id"]);
            c.Name = Request.Form["name"].ToString();
            c.Address_ID = int.Parse(Request.Form["addressid"]);

            var cm = new CustomerModel();

            cm.EditCustomer(c);

            // TODO: This Should be dynamic. Not go to '1' all the time.
            return Redirect("/Admin/Edit/1");

        }

    }
}