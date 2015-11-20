using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Department
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public int Address { get; set; }
        public int Head { get; set; }

        public int AddressID { get; set; }

        public int DHeadID { get; set; }
    }
}