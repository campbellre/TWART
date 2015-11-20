using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Depot
    {
        public int ID { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public int ManagerID { get; set; }
        public Employee Manager { get; set; }
        public String DepotName { get; set; }
        public double FloorSpace { get; set; }
        public int NumVehicles { get; set; }
    }
}