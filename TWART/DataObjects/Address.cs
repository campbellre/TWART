using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Address
    {
        public int ID { get; set; }
        public String LineOne { get; set; }
        public String LineTwo { get; set; }
        public String LineThree { get; set; }
        public String LineFour { get; set; }
        public String LineFive { get; set; }
        public String State { get; set; }
        public String County { get; set; }
        public String Country { get; set; }
        public String PostalCode { get; set; }
    }
}