using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TWART.Controllers
{
    public class newController : System.Web.Mvc.Controller
    {
        // GET: new
        public string Index()
        {
            return "this is the <b>default</b> thing";
        }

        // GET: new
        public string Test()
        {
            return "this is the <b>test</b> thing";
        }
    }
}