using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TWART.Controllers
{
    public class IndexController : System.Web.Mvc.Controller
    {
        //
        // GET: /Index/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminIndex()
        {
            return View();
        }

        public ActionResult ClientIndex()
        {
            return View();
        }
	}
}