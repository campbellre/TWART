using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Package
    {
        public int ID { get; set; }
        public Specification Specification { get; set; }
        public Goods Goods { get; set; }
    }
}