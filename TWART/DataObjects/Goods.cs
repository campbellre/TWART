using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Goods
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public Transport Transport { get; set; }
        public int TransportID { get; set; }
        public String HandlingRequirments { get; set; }
    }
}