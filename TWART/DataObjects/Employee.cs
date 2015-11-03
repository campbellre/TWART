using System;

namespace TWART.DataObjects
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Dob { get; set; }
        public string ContactNumber { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public int Dept { get; set; }
        public int Depot { get; set; }
        public int Role { get; set; }


    }
}