using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWART.Controller;

namespace TWART.DataObjects
{
    public class Transaction
    {
        public int ID { get; set; }
        public DateTime DateOfOrder { get; set; }
        public CreateOrder Order { get; set; }
        public Customer Customer { get; set; }
        public Bank Bank { get; set; }
    }
}