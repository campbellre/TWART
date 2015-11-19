﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Account
    {
        // accessors and mutators
        public int ID { get; set; }
        public Contact Contact { get; set; }
        public Customer Customer { get; set; }
        public Account_Type AccountType { get; set; }
        public Bank Bank { get; set; }
        public int BankID { get; set; }
    }
}