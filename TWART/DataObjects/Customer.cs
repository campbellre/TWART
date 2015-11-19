using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Customer
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public Address Address { get; set; }
        public int Address_ID { get; set; }
        public int Account_ID { get; set; }
    }
}