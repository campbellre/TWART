using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TWART.Controllers
{
    public class HelloWorldController : System.Web.Mvc.Controller
    {
        // GET: HelloWorld
        public string Index()
        {
            return "DEFAULT";
        }

        // GET: HelloWorld/Test
        public string Test()
        {
            return "TEST";
        }
    }
}