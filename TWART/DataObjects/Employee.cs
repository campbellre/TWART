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
        public int Dept { get; set; }
        public int Depot { get; set; }
        public int Role { get; set; }

        public String GetDOBString()
        {
            return this.DOB.ToString(dateFormat);
        }

        public String GetStartDateString()
        {
            return this.Startdate.ToString(dateFormat);
        }

        public String GetEndDateString()
        {
            return this.EndDate.ToString(dateFormat);
        }
    }
}