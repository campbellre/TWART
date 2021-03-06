using System;
using System.Configuration;

namespace TWART.DataObjects
{
    public class Employee
    {
        private string dateFormat = "yyyy-MM-dd";

        public int Id { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public DateTime DOB { get; set; }
        public String ContactNumber { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public Department Department { get; set; }
        public Depot DepotO { get; set; }
        public Role RoleO { get; set; }
        public int Dept { get; set; }
        public int Depot { get; set; }
        public int Role { get; set; }
    }
}