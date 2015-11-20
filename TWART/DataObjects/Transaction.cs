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
        public Order Order { get; set; }
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }
        public Bank Bank { get; set; }
        public int BankID { get; set; }
    }
}