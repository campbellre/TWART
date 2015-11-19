using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Bank
    {
        public int ID { get; set; }
        public Address Address { get; set; }
        public int Address_ID { get; set; }
        public String SortCode { get; set; }
        public int AccountNumber { get; set; }
        public Customer Customer { get; set; }
        public int Customer_ID { get; set; }

    }
}